
namespace Zenkov1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.EncryptionButton = new System.Windows.Forms.Button();
            this.DencryptionButton = new System.Windows.Forms.Button();
            this.BreakingButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.keyInputTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(12, 12);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputTextBox.Size = new System.Drawing.Size(391, 618);
            this.InputTextBox.TabIndex = 0;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(409, 12);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(391, 618);
            this.ResultTextBox.TabIndex = 1;
            // 
            // EncryptionButton
            // 
            this.EncryptionButton.Location = new System.Drawing.Point(813, 13);
            this.EncryptionButton.Name = "EncryptionButton";
            this.EncryptionButton.Size = new System.Drawing.Size(111, 31);
            this.EncryptionButton.TabIndex = 2;
            this.EncryptionButton.Text = "Зашифровать";
            this.EncryptionButton.UseVisualStyleBackColor = true;
            this.EncryptionButton.Click += new System.EventHandler(this.EncryptionButton_Click);
            // 
            // DencryptionButton
            // 
            this.DencryptionButton.Location = new System.Drawing.Point(813, 50);
            this.DencryptionButton.Name = "DencryptionButton";
            this.DencryptionButton.Size = new System.Drawing.Size(111, 31);
            this.DencryptionButton.TabIndex = 3;
            this.DencryptionButton.Text = "Расшифровать";
            this.DencryptionButton.UseVisualStyleBackColor = true;
            this.DencryptionButton.Click += new System.EventHandler(this.DencryptionButton_Click);
            // 
            // BreakingButton
            // 
            this.BreakingButton.Location = new System.Drawing.Point(813, 137);
            this.BreakingButton.Name = "BreakingButton";
            this.BreakingButton.Size = new System.Drawing.Size(111, 31);
            this.BreakingButton.TabIndex = 4;
            this.BreakingButton.Text = "Взломать";
            this.BreakingButton.UseVisualStyleBackColor = true;
            this.BreakingButton.Click += new System.EventHandler(this.BreakingButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(813, 199);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(111, 31);
            this.ClearButton.TabIndex = 10;
            this.ClearButton.Text = "Очистить поля";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // keyInputTextBox
            // 
            this.keyInputTextBox.Location = new System.Drawing.Point(813, 100);
            this.keyInputTextBox.Multiline = true;
            this.keyInputTextBox.Name = "keyInputTextBox";
            this.keyInputTextBox.Size = new System.Drawing.Size(111, 31);
            this.keyInputTextBox.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(810, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ключ шифра:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 642);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keyInputTextBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.BreakingButton);
            this.Controls.Add(this.DencryptionButton);
            this.Controls.Add(this.EncryptionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaesarCipher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Button EncryptionButton;
        private System.Windows.Forms.Button DencryptionButton;
        private System.Windows.Forms.Button BreakingButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox keyInputTextBox;
        private System.Windows.Forms.Label label2;
    }
}

