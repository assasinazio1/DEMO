using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace FurnitureShopApp.Forms
{
    partial class ProductListForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView productsGrid;
        private System.Windows.Forms.Button backButton;

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
            this.productsGrid = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsGrid)).BeginInit();
            this.SuspendLayout();

            // Сетка продуктов

            this.productsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productsGrid.Location = new System.Drawing.Point(12, 12);
            this.productsGrid.Name = "ProductsGrid";
            this.productsGrid.ReadOnly = true;
            this.productsGrid.Size = new System.Drawing.Size(760, 300);
            this.productsGrid.TabIndex = 0;

            // кнопка назад

            this.backButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(12, 318);
            this.backButton.Name = "BackButton";
            this.backButton.Size = new System.Drawing.Size(100, 30);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);

            // Форма списка продуктов

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ColorTranslator.FromHtml("#BFD6F6");
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.productsGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProductListForm";
            this.Text = "Материал корпуса изделия";
            ((System.ComponentModel.ISupportInitialize)(this.productsGrid)).EndInit();
            this.ResumeLayout(false);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}