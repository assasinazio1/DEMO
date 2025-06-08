using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace FurnitureShopApp.Forms
{
    public partial class ProductListForm : Form
    {
        private readonly string connectionString;
        private readonly int materialId;

        public ProductListForm(string connectionString, int materialId)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Образ_плюс;
            this.connectionString = connectionString;
            this.materialId = materialId;
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT p.ProductName, pm.MaterialQuantity
                        FROM Products p
                        JOIN ProductMaterials pm ON p.ProductId = pm.ProductId
                        WHERE pm.MaterialId = @MaterialId";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@MaterialId", materialId);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        productsGrid.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки продуктов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
    }
}