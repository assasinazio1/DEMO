using System.Drawing;

namespace FurnitureShopApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView materialsGrid;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button viewProductsButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button lowStockButton;
        private System.Windows.Forms.Button calculatorButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.materialsGrid = new System.Windows.Forms.DataGridView();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.viewProductsButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.lowStockButton = new System.Windows.Forms.Button();
            this.calculatorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();

            // Сетка материалов

            this.materialsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.materialsGrid.Location = new System.Drawing.Point(12, 70);
            this.materialsGrid.Name = "materialsGrid";
            this.materialsGrid.ReadOnly = true;
            this.materialsGrid.Size = new System.Drawing.Size(760, 300);
            this.materialsGrid.TabIndex = 0;
            this.materialsGrid.DoubleClick += new System.EventHandler(this.materialsGrid_DoubleClick);

            // Лого

            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(100, 50);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 1;
            this.logoPictureBox.TabStop = false;

            // Кнопка добавить

            this.addButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(12, 376);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 30);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить материал";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);

            // Кнопка просмотра продуктов

            this.viewProductsButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.viewProductsButton.ForeColor = System.Drawing.Color.White;
            this.viewProductsButton.Location = new System.Drawing.Point(118, 376);
            this.viewProductsButton.Name = "viewProductsButton";
            this.viewProductsButton.Size = new System.Drawing.Size(100, 30);
            this.viewProductsButton.TabIndex = 3;
            this.viewProductsButton.Text = "Просмотр продуктов";
            this.viewProductsButton.UseVisualStyleBackColor = false;
            this.viewProductsButton.Click += new System.EventHandler(this.viewProductsButton_Click);

            // Кнопка обновить

            this.refreshButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.refreshButton.ForeColor = System.Drawing.Color.White;
            this.refreshButton.Location = new System.Drawing.Point(224, 376);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Обновить";
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.LoadMaterials);

            // Кнопка показа низкого количества

            this.lowStockButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.lowStockButton.ForeColor = System.Drawing.Color.White;
            this.lowStockButton.Location = new System.Drawing.Point(330, 376);
            this.lowStockButton.Name = "lowStockButton";
            this.lowStockButton.Size = new System.Drawing.Size(100, 30);
            this.lowStockButton.TabIndex = 5;
            this.lowStockButton.Text = "Низкий запас";
            this.lowStockButton.UseVisualStyleBackColor = false;
            this.lowStockButton.Click += new System.EventHandler(this.lowStockButton_Click);

            // Кнопка калькулятор

            this.calculatorButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.calculatorButton.ForeColor = System.Drawing.Color.White;
            this.calculatorButton.Location = new System.Drawing.Point(436, 376);
            this.calculatorButton.Name = "calculatorButton";
            this.calculatorButton.Size = new System.Drawing.Size(100, 30);
            this.calculatorButton.TabIndex = 6;
            this.calculatorButton.Text = "Калькулятор";
            this.calculatorButton.UseVisualStyleBackColor = false;
            this.calculatorButton.Click += new System.EventHandler(this.calculatorButton_Click);

            // MainForm

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(780, 411);
            this.Controls.Add(this.calculatorButton);
            this.Controls.Add(this.lowStockButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.viewProductsButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.materialsGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Образ плюс - Управление материалами";
            ((System.ComponentModel.ISupportInitialize)(this.materialsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}