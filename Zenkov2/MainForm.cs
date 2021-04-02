using System;
using System.Text.RegularExpressions;
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
            var input = ClearText(InputTextBox.Text);
            var key = ClearTextWithError(DecryptionKeyTextBox.Text);
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(key))
                ResultTextBox.Text = TextWithSpaces(cipher.Encrypting(input, key));
        }
        private void DencryptionButton_Click(object sender, EventArgs e)
        {
            var input = ClearText(InputTextBox.Text);
            var key = ClearTextWithError(DecryptionKeyTextBox.Text);
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(key))
                ResultTextBox.Text = TextWithSpaces(cipher.Decrypting(input, key));
        }
        private void BreakingButton_Click(object sender, EventArgs e)
        {
            var input = ClearText(InputTextBox.Text);
            if (!string.IsNullOrEmpty(input))
            {
                var result = cipher.Breaking(ClearText(InputTextBox.Text));
                ResultTextBox.Text = TextWithSpaces(result.text);
                DecryptionKeyTextBox.Text = (string)result.cipherKey;
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            InputTextBox.Text = "";
            ResultTextBox.Text = "";
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
            char[] output = new char[text.Length + text.Length / 5];
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
