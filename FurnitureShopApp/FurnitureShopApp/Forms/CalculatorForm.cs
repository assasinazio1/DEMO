using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using FurnitureShopApp.Utilities;

namespace FurnitureShopApp.Forms
{
    public partial class CalculatorForm : Form
    {
        private readonly string connectionString;

        public CalculatorForm(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            LoadProductTypes();
            LoadMaterials();
        }

        private void LoadProductTypes()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ProductTypeId, TypeName FROM ProductTypes";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        productTypeCombo.DataSource = dataTable;
                        productTypeCombo.DisplayMember = "TypeName";
                        productTypeCombo.ValueMember = "ProductTypeId";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке типов продуктов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void LoadMaterials()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MaterialId, MaterialName FROM Materials";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        materialCombo.DataSource = dataTable;
                        materialCombo.DisplayMember = "MaterialName";
                        materialCombo.ValueMember = "MaterialId";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке материалов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                int productTypeId = Convert.ToInt32(productTypeCombo.SelectedValue);
                int materialId = Convert.ToInt32(materialCombo.SelectedValue);
                int materialQuantity = int.Parse(materialQuantityText.Text);
                double param1 = double.Parse(param1Text.Text);
                double param2 = double.Parse(param2Text.Text);

                int result = ProductionCalculator.CalculateProductQuantity(productTypeId, materialId, materialQuantity, param1, param2, connectionString);
                if (result == -1)
                {
                    MessageBox.Show("Неверный ввод или отсутствие указанного типа продукта/материала.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Производимое количество: {result} штук", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете количества: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (productTypeCombo.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип продукта.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (materialCombo.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, выберите материал.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(materialQuantityText.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Количество материала должно быть положительным целым числом.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(param1Text.Text, out double param1) || param1 <= 0)
            {
                MessageBox.Show("Параметр 1 должен быть положительным числом.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(param2Text.Text, out double param2) || param2 <= 0)
            {
                MessageBox.Show("Параметр 2 должен быть положительным числом.", "Ошибка проверки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}