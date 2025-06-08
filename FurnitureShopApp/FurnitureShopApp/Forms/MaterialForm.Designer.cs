using System;
using System.Drawing;

namespace FurnitureShopApp.Forms
{
    partial class MaterialForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox materialTypeCombo;
        private System.Windows.Forms.TextBox materialNameText;
        private System.Windows.Forms.TextBox priceText;
        private System.Windows.Forms.TextBox unitText;
        private System.Windows.Forms.TextBox packageQtyText;
        private System.Windows.Forms.TextBox stockQtyText;
        private System.Windows.Forms.TextBox minQtyText;
        private System.Windows.Forms.Button saveButton;
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
            this.materialTypeCombo = new System.Windows.Forms.ComboBox();
            this.materialNameText = new System.Windows.Forms.TextBox();
            this.priceText = new System.Windows.Forms.TextBox();
            this.unitText = new System.Windows.Forms.TextBox();
            this.packageQtyText = new System.Windows.Forms.TextBox();
            this.stockQtyText = new System.Windows.Forms.TextBox();
            this.minQtyText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Комбинированный тип материала

            this.materialTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialTypeCombo.Location = new System.Drawing.Point(120, 12);
            this.materialTypeCombo.Name = "materialTypeCombo";
            this.materialTypeCombo.Size = new System.Drawing.Size(200, 21);
            this.materialTypeCombo.TabIndex = 0;

            // Название материала

            this.materialNameText.Location = new System.Drawing.Point(120, 39);
            this.materialNameText.Name = "materialNameText";
            this.materialNameText.Size = new System.Drawing.Size(200, 20);
            this.materialNameText.TabIndex = 1;

            // Цена

            this.priceText.Location = new System.Drawing.Point(120, 66);
            this.priceText.Name = "priceText";
            this.priceText.Size = new System.Drawing.Size(200, 20);
            this.priceText.TabIndex = 2;

            // Единица измерения

            this.unitText.Location = new System.Drawing.Point(120, 93);
            this.unitText.Name = "unitText";
            this.unitText.Size = new System.Drawing.Size(200, 20);
            this.unitText.TabIndex = 3;

            // Количество упаковок

            this.packageQtyText.Location = new System.Drawing.Point(120, 120);
            this.packageQtyText.Name = "packageQtyText";
            this.packageQtyText.Size = new System.Drawing.Size(200, 20);
            this.packageQtyText.TabIndex = 4;

            //Количество на складе

            this.stockQtyText.Location = new System.Drawing.Point(120, 147);
            this.stockQtyText.Name = "stockQtyText";
            this.stockQtyText.Size = new System.Drawing.Size(200, 20);
            this.stockQtyText.TabIndex = 5;

            // Минимальное количество

            this.minQtyText.Location = new System.Drawing.Point(120, 174);
            this.minQtyText.Name = "minQtyText";
            this.minQtyText.Size = new System.Drawing.Size(200, 20);
            this.minQtyText.TabIndex = 6;

            // Кнопка Сохранить

            this.saveButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(120, 201);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 30);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);

            // Кнопка назад

            this.cancelButton.BackColor = ColorTranslator.FromHtml("#405C73");
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(226, 201);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Назад";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);

            // Форма материалов

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ColorTranslator.FromHtml("#BFD6F6");
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.minQtyText);
            this.Controls.Add(this.stockQtyText);
            this.Controls.Add(this.packageQtyText);
            this.Controls.Add(this.unitText);
            this.Controls.Add(this.priceText);
            this.Controls.Add(this.materialNameText);
            this.Controls.Add(this.materialTypeCombo);
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Тип материала:", Location = new System.Drawing.Point(12, 12) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Название материала:", Location = new System.Drawing.Point(12, 39) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Цена за штуку:", Location = new System.Drawing.Point(12, 66) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Ед.измерения:", Location = new System.Drawing.Point(12, 93) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Кол-во в упак:", Location = new System.Drawing.Point(12, 120) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Кол-во на складе:", Location = new System.Drawing.Point(12, 147) });
            this.Controls.Add(new System.Windows.Forms.Label { Text = "Мин.количество:", Location = new System.Drawing.Point(12, 174) });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MaterialForm";
            this.Text = "Добавить материал";
            this.Load += new System.EventHandler(this.MaterialForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MaterialForm_Load(object sender, EventArgs e)
        {
            if (materialId.HasValue)
                this.Text = "Изменить материал";
        }
    }
}