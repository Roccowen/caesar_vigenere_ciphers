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
using Zenkov1;

namespace Zenkov2
{
    public partial class MainForm : Form
    {
        private static ICipher cipher = new VigenereCipher();
        private static Regex textRegex = new Regex(@"[^А-ЯЁ]");
        public MainForm()
        {
            InitializeComponent();
        }
        private void EncryptionButton_Click(object sender, EventArgs e)
        {
            var inp = ClearText(InputTextBox.Text);
            var k = ClearText(DecryptionKeyTextBox.Text);
            if (inp != null && k != null)
                ResultTextBox.Text = TextWithSpaces(cipher.Encrypting(ClearText(InputTextBox.Text),
                                            ClearTextWithError(DecryptionKeyTextBox.Text)));
        }
        private void DencryptionButton_Click(object sender, EventArgs e)
        {
            var inp = ClearText(InputTextBox.Text);
            var k = ClearText(DecryptionKeyTextBox.Text);
            if (inp != null && k != null)
                ResultTextBox.Text = TextWithSpaces(cipher.Decrypting(ClearText(InputTextBox.Text),
                                            ClearTextWithError(DecryptionKeyTextBox.Text)));
        }
        private void BreakingButton_Click(object sender, EventArgs e)
        {
            if (ClearText(InputTextBox.Text) != "" && ClearText(InputTextBox.Text) != null)
            {
                var result = cipher.Breaking(ClearText(InputTextBox.Text));
                ResultTextBox.Text = TextWithSpaces(result.text);
                BreakingKeyTextBox.Text = (string)result.cipherKey;
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "";
            ResultTextBox.Text = "";
            BreakingKeyTextBox.Text = "";
            DecryptionKeyTextBox.Text = "";
        }
        private static string ClearText(string text)
        {
            var clearText = text.ToUpper().Replace("Ё", "Е");
            return textRegex.Replace(clearText, "");
        }
        private static string ClearTextWithError(string text)
        {
            var clearText = text.ToUpper().Replace("Ё", "Е");
            if (textRegex.IsMatch(clearText))
            {
                MessageBox.Show("Ключ может содержать только русские буквы",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return null;
            }
            return textRegex.Replace(clearText, "");
        }
        private static string TextWithSpaces(string text)
        {
            string output = "";
            for (int i = 0, c = 1; i < text.Length; i++, c++)
            {
                output += text[i];
                if (c == 5)
                {
                    output += " ";
                    c = 0;
                }
            }
            return output;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
