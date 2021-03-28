using System;
using System.Collections.Generic;
using System.Linq;

namespace Zenkov1
{
    public class CaesarCipher : ICipher
    {
        private char EncryptionAlg(char c, int key, char[] alphabet) => 
            alphabet[(alphabet.Length + (Array.IndexOf(alphabet, c) + key % alphabet.Length)) % alphabet.Length];
        private char DecryptionAlg(char c, int key, char[] alphabet) =>
            alphabet[(alphabet.Length + (Array.IndexOf(alphabet, c) - key % alphabet.Length)) % alphabet.Length]; 
        public string Encrypting(string text, object key)
        {
            var output = "";
            foreach (char c in text)
                if (c >= 1040 && c <= 1071)
                    output += EncryptionAlg(c, (int)key, cyrillicAlphabet.ToCharArray());
                else
                    output += EncryptionAlg(c, (int)key, latinAlphabet.ToCharArray());
            return output;
        }
        public string Decrypting(string cipher, object key)
        {
            var output = "";
            foreach (char c in cipher)
                if (c >= 1040 && c <= 1071)
                    output += DecryptionAlg(c, (int)key, cyrillicAlphabet.ToCharArray());
                else
                    output += DecryptionAlg(c, (int)key, latinAlphabet.ToCharArray());
            return output;
        }
        public (string text, string cipherKey) Breaking(string cipher)
        {
            var currentAlphabetOccurrence = GetGlobalAlphabetOccurrence();
            List<double> DAll = new List<double>();
            var cipherAlph = cipher.ToHashSet().OrderBy(c => (int)c).ToList();
            int alph = 32 < cipherAlph.Count ? cipherAlph.Count : 32;
            for (int i = 0; i < alph; i++)
            {
                double D = 0.00;
                var currentOccurence = new Dictionary<char, double>();
                var cipherDec = Decrypting(cipher, i);
                foreach (char c in cipherAlph)
                {
                    currentOccurence.Add(c, (double)cipherDec.CharCount(c) / (double)cipherDec.Length);
                    D += Math.Pow(currentAlphabetOccurrence[c] - currentOccurence[c], 2);
                }
                DAll.Add(D);
            }
            var foundedKey = DAll.IndexOf(DAll.Min());
            return (Decrypting(cipher, foundedKey), foundedKey.ToString());
        }
        private string cyrillicAlphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string latinAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static Dictionary<char, double> GetGlobalAlphabetOccurrence()
        {
            var occ = new Dictionary<char, double>();
            occ.Add('А', 0.062);
            occ.Add('Б', 0.014);
            occ.Add('В', 0.038);
            occ.Add('Г', 0.013);
            occ.Add('Д', 0.025);
            occ.Add('Е', 0.072);
            occ.Add('Ж', 0.007);
            occ.Add('З', 0.016);
            occ.Add('И', 0.062);
            occ.Add('Й', 0.010);
            occ.Add('К', 0.028);
            occ.Add('Л', 0.035);
            occ.Add('М', 0.026);
            occ.Add('Н', 0.053);
            occ.Add('О', 0.090);
            occ.Add('П', 0.023);
            occ.Add('Р', 0.040);
            occ.Add('С', 0.045);
            occ.Add('Т', 0.053);
            occ.Add('У', 0.021);
            occ.Add('Ф', 0.002);
            occ.Add('Х', 0.009);
            occ.Add('Ц', 0.003);
            occ.Add('Ч', 0.012);
            occ.Add('Ш', 0.006);
            occ.Add('Щ', 0.003);
            occ.Add('Ъ', 0.014);
            occ.Add('Ы', 0.016);
            occ.Add('Ь', 0.014);
            occ.Add('Э', 0.003);
            occ.Add('Ю', 0.006);
            occ.Add('Я', 0.018);
            occ.Add('A', 0.0796);
            occ.Add('B', 0.0160);
            occ.Add('C', 0.0284);
            occ.Add('D', 0.0401);
            occ.Add('E', 0.1286);
            occ.Add('F', 0.0262);
            occ.Add('G', 0.0199);
            occ.Add('H', 0.0539);
            occ.Add('I', 0.0777);
            occ.Add('J', 0.0016);
            occ.Add('K', 0.0041);
            occ.Add('L', 0.0351);
            occ.Add('M', 0.0243);
            occ.Add('N', 0.0751);
            occ.Add('O', 0.0662);
            occ.Add('P', 0.0181);
            occ.Add('Q', 0.0017);
            occ.Add('R', 0.0683);
            occ.Add('S', 0.0662);
            occ.Add('T', 0.0972);
            occ.Add('U', 0.0248);
            occ.Add('V', 0.0115);
            occ.Add('W', 0.0180);
            occ.Add('X', 0.0017);
            occ.Add('Y', 0.0152);
            occ.Add('Z', 0.0005);
            return occ;
        }
    }
    public  static class StringExtension
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == c)
                    counter++;
            return counter;
        }
    }
}
