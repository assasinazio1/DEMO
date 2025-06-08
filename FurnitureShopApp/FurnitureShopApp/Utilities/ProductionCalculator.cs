using System;
using System.Data.SqlClient;

namespace FurnitureShopApp.Utilities
{
    public static class ProductionCalculator
    {
        public static int CalculateProductQuantity(int productTypeId, int materialId, int materialQuantity,
                                                double param1, double param2, string connectionString)
        {
            if (materialQuantity <= 0 || param1 <= 0 || param2 <= 0)
            {
                return -1;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string productQuery = "SELECT TypeCoefficient FROM ProductTypes WHERE ProductTypeId = @ProductTypeId";
                    using (SqlCommand productCommand = new SqlCommand(productQuery, connection))
                    {
                        productCommand.Parameters.AddWithValue("@ProductTypeId", productTypeId);
                        object coefficientObj = productCommand.ExecuteScalar();
                        if (coefficientObj == null)
                        {
                            return -1;
                        }
                        double typeCoefficient = Convert.ToDouble(coefficientObj);

                        string materialQuery = @"
                            SELECT mt.WastagePercentage 
                            FROM MaterialTypes mt 
                            JOIN Materials m ON mt.MaterialTypeId = m.MaterialTypeId 
                            WHERE m.MaterialId = @MaterialId";
                        using (SqlCommand materialCommand = new SqlCommand(materialQuery, connection))
                        {
                            materialCommand.Parameters.AddWithValue("@MaterialId", materialId);
                            object wastageObj = materialCommand.ExecuteScalar();
                            if (wastageObj == null)
                            {
                                return -1;
                            }
                            double wastagePercentage = Convert.ToDouble(wastageObj);

                            // Рассчёт количества материала, необходимого для каждой единицы продукции
                            double materialPerProduct = param1 * param2 * typeCoefficient;
                            double usableMaterial = materialQuantity * (1 - wastagePercentage / 100.0);
                            int producibleQuantity = (int)Math.Floor(usableMaterial / materialPerProduct);
                            return producibleQuantity;
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}