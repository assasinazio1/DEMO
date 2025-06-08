using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace FurnitureShopApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly string connectionString;

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Образ_плюс; // Use embedded resource
            logoPictureBox.Image = Properties.Resources.Образ_плюс1;
            connectionString = ConfigurationManager.ConnectionStrings["FurnitureShopConnection"].ConnectionString;
            LoadMaterials(this, EventArgs.Empty);
        }

        private void LoadMaterials(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT m.MaterialId, mt.MaterialName AS MaterialType, m.MaterialName, m.PricePerUnit, m.Unit, 
                               m.PackageQuantity, m.StockQuantity, m.MinimumQuantity
                        FROM Materials m
                        JOIN MaterialTypes mt ON m.MaterialTypeId = mt.MaterialTypeId";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        materialsGrid.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке материалов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MaterialForm addForm = new MaterialForm(connectionString);
            addForm.ShowDialog();
            LoadMaterials(this, EventArgs.Empty);
        }

        private void materialsGrid_DoubleClick(object sender, EventArgs e)
        {
            if (materialsGrid.SelectedRows.Count > 0)
            {
                int materialId = Convert.ToInt32(materialsGrid.SelectedRows[0].Cells["MaterialId"].Value);
                MaterialForm editForm = new MaterialForm(connectionString, materialId);
                editForm.ShowDialog();
                LoadMaterials(this, EventArgs.Empty);
            }
        }

        private void viewProductsButton_Click(object sender, EventArgs e)
        {
            if (materialsGrid.SelectedRows.Count > 0)
            {
                int materialId = Convert.ToInt32(materialsGrid.SelectedRows[0].Cells["MaterialId"].Value);
                ProductListForm productForm = new ProductListForm(connectionString, materialId);
                productForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите материал.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lowStockButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT m.MaterialId, mt.MaterialName AS MaterialType, m.MaterialName, m.PricePerUnit, m.Unit, 
                               m.PackageQuantity, m.StockQuantity, m.MinimumQuantity
                        FROM Materials m
                        JOIN MaterialTypes mt ON m.MaterialTypeId = mt.MaterialTypeId
                        WHERE m.StockQuantity < m.MinimumQuantity";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        materialsGrid.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке материалов с низким запасом: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calculatorButton_Click(object sender, EventArgs e)
        {
            CalculatorForm calcForm = new CalculatorForm(connectionString);
            calcForm.ShowDialog();
        }
    }
}