using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace FurnitureShopApp.Forms
{
    public partial class MaterialForm : Form
    {
        private readonly string connectionString;
        private readonly int? materialId;

        public MaterialForm(string connectionString, int? materialId = null)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Образ_плюс;
            this.connectionString = connectionString;
            this.materialId = materialId;
            LoadMaterialTypes();
            if (materialId.HasValue) LoadMaterial();
        }

        private void LoadMaterialTypes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaterialTypeId, MaterialName FROM MaterialTypes";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        materialTypeCombo.DataSource = dataTable;
                        materialTypeCombo.DisplayMember = "MaterialName";
                        materialTypeCombo.ValueMember = "MaterialTypeId";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке типов материалов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void LoadMaterial()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT MaterialTypeId, MaterialName, PricePerUnit, Unit, PackageQuantity, StockQuantity, MinimumQuantity
                        FROM Materials WHERE MaterialId = @MaterialId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaterialId", materialId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                materialTypeCombo.SelectedValue = reader["MaterialTypeId"];
                                materialNameText.Text = reader["MaterialName"].ToString();
                                priceText.Text = reader["PricePerUnit"].ToString();
                                unitText.Text = reader["Unit"].ToString();
                                packageQtyText.Text = reader["PackageQuantity"].ToString();
                                stockQtyText.Text = reader["StockQuantity"].ToString();
                                minQtyText.Text = reader["MinimumQuantity"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке материала: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = materialId.HasValue ?
                        @"UPDATE Materials SET MaterialTypeId = @MaterialTypeId, MaterialName = @MaterialName, 
                               PricePerUnit = @PricePerUnit, Unit = @Unit, PackageQuantity = @PackageQuantity, 
                               StockQuantity = @StockQuantity, MinimumQuantity = @MinimumQuantity 
                               WHERE MaterialId = @MaterialId" :
                        @"INSERT INTO Materials (MaterialTypeId, MaterialName, PricePerUnit, Unit, PackageQuantity, StockQuantity, MinimumQuantity)
                          VALUES (@MaterialTypeId, @MaterialName, @PricePerUnit, @Unit, @PackageQuantity, @StockQuantity, @MinimumQuantity)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaterialTypeId", materialTypeCombo.SelectedValue);
                        command.Parameters.AddWithValue("@MaterialName", materialNameText.Text);
                        command.Parameters.AddWithValue("@PricePerUnit", decimal.Parse(priceText.Text));
                        command.Parameters.AddWithValue("@Unit", unitText.Text);
                        command.Parameters.AddWithValue("@PackageQuantity", int.Parse(packageQtyText.Text));
                        command.Parameters.AddWithValue("@StockQuantity", int.Parse(stockQtyText.Text));
                        command.Parameters.AddWithValue("@MinimumQuantity", int.Parse(minQtyText.Text));
                        if (materialId.HasValue)
                            command.Parameters.AddWithValue("@MaterialId", materialId.Value);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Материал успешно сохранен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения материала: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (materialTypeCombo.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип материала.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(materialNameText.Text))
            {
                MessageBox.Show("Укажите название материала.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(priceText.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Цена должна быть неотрицательным числом с точностью до двух знаков после запятой.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(unitText.Text))
            {
                MessageBox.Show("Укажите единицу измерения.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(packageQtyText.Text, out int packageQty) || packageQty <= 0)
            {
                MessageBox.Show("Количество упаковок должно быть положительным целым числом.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(stockQtyText.Text, out int stockQty) || stockQty < 0)
            {
                MessageBox.Show("Количество товара должно быть неотрицательным целым числом.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(minQtyText.Text, out int minQty) || minQty < 0)
            {
                MessageBox.Show("Минимальное количество должно быть неотрицательным целым числом.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}