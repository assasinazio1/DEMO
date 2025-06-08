using System;
using System.Drawing;

namespace FurnitureShopApp.Forms
{
    partial class CalculatorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox productTypeCombo;
        private System.Windows.Forms.ComboBox materialCombo;
        private System.Windows.Forms.TextBox materialQuantityText;
        private System.Windows.Forms.TextBox param1Text;
        private System.Windows.Forms.TextBox param2Text;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button cancelButton;

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
            this.productTypeCombo = new System.Windows.Forms.ComboBox();
            this.materialCombo = new System.Windows.Forms.ComboBox();
            this.materialQuantityText = new System.Windows.Forms.TextBox();
            this.param1Text = new System.Windows.Forms.TextBox();
            this.param2Text = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Комбинированный тип продукта

            this.productTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productTypeCombo.Location = new System.Drawing.Point(120, 12);
            this.productTypeCombo.Name = "productTypeCombo";
            this.productTypeCombo.Size = new System.Drawing.Size(200, 21);
            this.productTypeCombo.TabIndex = 0;

            // Комбинированный материал

            this.materialCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialCombo.Location = new System.Drawing.Point(120, 39);
            this.materialCombo.Name = "materialCombo";
            this.materialCombo.Size = new System.Drawing.Size(200, 21);
            this.materialCombo.TabIndex = 1;

            // Количество материала

            this.materialQuantityText.Location = new System.Drawing.Point(120, 66);
            this.materialQuantityText.Name = "materialQuantityText";
            this.materialQuantityText.Size = new System.Drawing.Size(200, 20);
            this.materialQuantityText.TabIndex = 2;

            // Параметр 1

            this.param1Text.Location = new System.Drawing.Point(120, 93);
            this.param1Text.Name = "param1Text";
            this.param1Text.Size = new System.Drawing.Size(200, 20);
            this.param1Text.TabIndex = 3;

            // Параметр 2

            this.param2Text.Location = new System.Drawing.Point(120, 120);
            this.param2Text.Name = "param2Text";
            this.param2Text.Size = new System.Drawing.Size(200, 20);
            this.param2Text.TabIndex = 4;

            // Кнопка расчета

            this.calculateButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.calculateButton.ForeColor = System.Drawing.Color.White;
            this.calculateButton.Location = new System.Drawing.Point(120, 147);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(100, 30);
            this.calculateButton.TabIndex = 5;
            this.calculateButton.Text = "Вычислить";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);

            // Кнопка закрыть

            this.cancelButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(226, 147);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Назад";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // Форма калькулятора

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ColorTranslator.FromHtml("#BFD6F6");
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.param2Text);
            this.Controls.Add(this.param1Text);
            this.Controls.Add(this.materialQuantityText);
            this.Controls.Add(this.materialCombo);
            this.Controls.Add(this.productTypeCombo);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Тип продукта:", Location = new System.Drawing.Point(12, 12) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Материал:", Location = new System.Drawing.Point(12, 39) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Количество материала:", Location = new System.Drawing.Point(12, 66) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Кол-во мат.на шт:", Location = new System.Drawing.Point(12, 93) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Процент отходов:", Location = new System.Drawing.Point(12, 120) });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CalculatorForm";
            this.Text = "Калькулятор продуктов";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}