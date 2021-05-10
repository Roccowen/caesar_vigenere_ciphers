using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenkov1
{
    public partial class MainForm : Form
    {
        private static readonly ICipher cipher = new CaesarCipher();
        private static readonly Regex textRegex = new Regex(@"[^A-ZА-ЯЁ]");
        public MainForm()
        {
            InitializeComponent();
        }
        private void EncryptionButton_Click(object sender, EventArgs e)
        {
            try
            {
                int key = int.Parse(keyInputTextBox.Text);
                ResultTextBox.Text = TextWithSpaces(cipher.Encrypting(ClearText(InputTextBox.Text), key));
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Ключ должен быть целым числом",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void DencryptionButton_Click(object sender, EventArgs e)
        {
            try
            {
                int key = int.Parse(keyInputTextBox.Text);
                ResultTextBox.Text = TextWithSpaces(cipher.Decrypting(ClearText(InputTextBox.Text), key));
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Ключ должен быть целым числом",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        private void BreakingButton_Click(object sender, EventArgs e)
        {
            if (ClearText(InputTextBox.Text) != "" && ClearText(InputTextBox.Text) != null)
            {
                var result = cipher.Breaking(ClearText(InputTextBox.Text));
                ResultTextBox.Text = TextWithSpaces(result.text);
                keyInputTextBox.Text = result.cipherKey;
            }          
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "";
            ResultTextBox.Text = "";
            keyInputTextBox.Text = "";

        }
        private static string ClearText(string text) 
        {
            var clearText = text.ToUpper().Replace("Ё","Е");
            return textRegex.Replace(clearText, "");
        }
        private static string TextWithSpaces(string text)
        {
            char[] output = new char[text.Length + text.Length/5];
            for (int i = 0, s = 0, c = 0; i < text.Length; i++, c++)
            {
                if (c == 5)
                {
                    output[i + s] = ' ';
                    s += 1;
                    c = 0;
                }
                output[i + s] = text[i];  
            }
            return new string(output);
        }
    }
}
