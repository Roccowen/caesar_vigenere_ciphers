
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
            this.EncriptionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DencriptionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ClearButton = new System.Windows.Forms.Button();
            this.BreakingKeyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EncriptionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DencriptionNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputTextBox.Location = new System.Drawing.Point(12, 12);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputTextBox.Size = new System.Drawing.Size(421, 618);
            this.InputTextBox.TabIndex = 0;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.Location = new System.Drawing.Point(453, 12);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ResultTextBox.Size = new System.Drawing.Size(421, 618);
            this.ResultTextBox.TabIndex = 1;
            // 
            // EncryptionButton
            // 
            this.EncryptionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EncryptionButton.Location = new System.Drawing.Point(915, 12);
            this.EncryptionButton.Name = "EncryptionButton";
            this.EncryptionButton.Size = new System.Drawing.Size(91, 23);
            this.EncryptionButton.TabIndex = 2;
            this.EncryptionButton.Text = "Зашифровать";
            this.EncryptionButton.UseVisualStyleBackColor = true;
            this.EncryptionButton.Click += new System.EventHandler(this.EncryptionButton_Click);
            // 
            // DencryptionButton
            // 
            this.DencryptionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DencryptionButton.Location = new System.Drawing.Point(915, 81);
            this.DencryptionButton.Name = "DencryptionButton";
            this.DencryptionButton.Size = new System.Drawing.Size(91, 23);
            this.DencryptionButton.TabIndex = 3;
            this.DencryptionButton.Text = "Расшифровать";
            this.DencryptionButton.UseVisualStyleBackColor = true;
            this.DencryptionButton.Click += new System.EventHandler(this.DencryptionButton_Click);
            // 
            // BreakingButton
            // 
            this.BreakingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BreakingButton.Location = new System.Drawing.Point(915, 152);
            this.BreakingButton.Name = "BreakingButton";
            this.BreakingButton.Size = new System.Drawing.Size(91, 23);
            this.BreakingButton.TabIndex = 4;
            this.BreakingButton.Text = "Взломать";
            this.BreakingButton.UseVisualStyleBackColor = true;
            this.BreakingButton.Click += new System.EventHandler(this.BreakingButton_Click);
            // 
            // EncriptionNumericUpDown
            // 
            this.EncriptionNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EncriptionNumericUpDown.Location = new System.Drawing.Point(915, 40);
            this.EncriptionNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.EncriptionNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.EncriptionNumericUpDown.Name = "EncriptionNumericUpDown";
            this.EncriptionNumericUpDown.Size = new System.Drawing.Size(91, 20);
            this.EncriptionNumericUpDown.TabIndex = 5;
            // 
            // DencriptionNumericUpDown
            // 
            this.DencriptionNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DencriptionNumericUpDown.Location = new System.Drawing.Point(915, 110);
            this.DencriptionNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.DencriptionNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.DencriptionNumericUpDown.Name = "DencriptionNumericUpDown";
            this.DencriptionNumericUpDown.Size = new System.Drawing.Size(91, 20);
            this.DencriptionNumericUpDown.TabIndex = 6;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(915, 235);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(91, 23);
            this.ClearButton.TabIndex = 10;
            this.ClearButton.Text = "Очистить поля";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // BreakingKeyLabel
            // 
            this.BreakingKeyLabel.AutoSize = true;
            this.BreakingKeyLabel.Location = new System.Drawing.Point(923, 178);
            this.BreakingKeyLabel.Name = "BreakingKeyLabel";
            this.BreakingKeyLabel.Size = new System.Drawing.Size(0, 13);
            this.BreakingKeyLabel.TabIndex = 11;
            this.BreakingKeyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 642);
            this.Controls.Add(this.BreakingKeyLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.DencriptionNumericUpDown);
            this.Controls.Add(this.EncriptionNumericUpDown);
            this.Controls.Add(this.BreakingButton);
            this.Controls.Add(this.DencryptionButton);
            this.Controls.Add(this.EncryptionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaesarCipher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EncriptionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DencriptionNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Button EncryptionButton;
        private System.Windows.Forms.Button DencryptionButton;
        private System.Windows.Forms.Button BreakingButton;
        private System.Windows.Forms.NumericUpDown EncriptionNumericUpDown;
        private System.Windows.Forms.NumericUpDown DencriptionNumericUpDown;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label BreakingKeyLabel;
    }
}

