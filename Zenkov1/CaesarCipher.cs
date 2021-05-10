using System;
using System.Collections.Generic;
using System.Linq;

namespace Zenkov1
{
    public class CaesarCipher : ICipher
    {
        private readonly string cyrillicAlphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private readonly string latinAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        // Табличные частоты.
        private readonly Dictionary<char, double> tableOccurence = new Dictionary<char, double>
            {
                { 'А', 0.062 },
                { 'Б', 0.014 },
                { 'В', 0.038 },
                { 'Г', 0.013 },
                { 'Д', 0.025 },
                { 'Е', 0.072 },
                { 'Ж', 0.007 },
                { 'З', 0.016 },
                { 'И', 0.062 },
                { 'Й', 0.010 },
                { 'К', 0.028 },
                { 'Л', 0.035 },
                { 'М', 0.026 },
                { 'Н', 0.053 },
                { 'О', 0.090 },
                { 'П', 0.023 },
                { 'Р', 0.040 },
                { 'С', 0.045 },
                { 'Т', 0.053 },
                { 'У', 0.021 },
                { 'Ф', 0.002 },
                { 'Х', 0.009 },
                { 'Ц', 0.003 },
                { 'Ч', 0.012 },
                { 'Ш', 0.006 },
                { 'Щ', 0.003 },
                { 'Ъ', 0.014 },
                { 'Ы', 0.016 },
                { 'Ь', 0.014 },
                { 'Э', 0.003 },
                { 'Ю', 0.006 },
                { 'Я', 0.018 },
                { 'A', 0.0796 },
                { 'B', 0.0160 },
                { 'C', 0.0284 },
                { 'D', 0.0401 },
                { 'E', 0.1286 },
                { 'F', 0.0262 },
                { 'G', 0.0199 },
                { 'H', 0.0539 },
                { 'I', 0.0777 },
                { 'J', 0.0016 },
                { 'K', 0.0041 },
                { 'L', 0.0351 },
                { 'M', 0.0243 },
                { 'N', 0.0751 },
                { 'O', 0.0662 },
                { 'P', 0.0181 },
                { 'Q', 0.0017 },
                { 'R', 0.0683 },
                { 'S', 0.0662 },
                { 'T', 0.0972 },
                { 'U', 0.0248 },
                { 'V', 0.0115 },
                { 'W', 0.0180 },
                { 'X', 0.0017 },
                { 'Y', 0.0152 },
                { 'Z', 0.0005 }
            };
        private char EncryptionAlg(char c, int key, char[] alphabet) => 
            alphabet[(alphabet.Length + (Array.IndexOf(alphabet, c) + key % alphabet.Length)) % alphabet.Length]; 
        public string Encrypting(string text, object key)
        {
            var output = "";
            foreach (char c in text)
                if (c >= 'А' && c <= 'Я')
                    output += EncryptionAlg(c, (int)key, cyrillicAlphabet.ToCharArray());
                else
                    output += EncryptionAlg(c, (int)key, latinAlphabet.ToCharArray());
            return output;
        }
        public string Decrypting(string cipher, object key) => Encrypting(cipher, -(int)key);
        // Взлом.
        public (string text, string cipherKey) Breaking(string cipher)
        {
            List<double> DAll = new List<double>();
            // Алфавит шифра.
            var cipherAlph = cipher.ToHashSet().ToList();
            for (int i = 0; i < 32; i++)
            {
                double D = 0.00;
                // Текущие частоты.
                var currentOccurence = new Dictionary<char, double>();
                var cipherDec = Decrypting(cipher, i);
                // Для каждой буквы в алфавите шифра вычисляется частота появления и D.
                foreach (char c in cipherAlph)
                {
                    // Количетсво букв делим на кол-во всех букв.
                    currentOccurence.Add(c, (double)cipherDec.CharCount(c) / (double)cipherDec.Length);
                    D += Math.Pow(tableOccurence[c] - currentOccurence[c], 2);
                }
                DAll.Add(D);
            }
            var foundedKey = DAll.IndexOf(DAll.Min());
            return (Decrypting(cipher, foundedKey), foundedKey.ToString());
        }
    }
}
