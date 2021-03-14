using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenkov1
{
    public class VigenereCipher : ICipher
    {
        private char[][] tabulaRecta;
        private CaesarCipher caesarCipher;
        const string cyrillicAlphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        public VigenereCipher()
        {
            tabulaRecta = GetTabulaRecta();
            caesarCipher = new CaesarCipher();
        }
        public string Encrypting(string text, object _key)
        {
            var output = "";
            string key = (string)_key;

            int[] keyArr = new int[text.Length];
            if (key.Length != 0)
            {
                for (int i = 0; i < keyArr.Length; i++)
                {
                    keyArr[i] = (int)key[i % key.Length] - 1040;
                    output += tabulaRecta[text[i] - 1040][keyArr[i]];
                }               
            }
            return output;
        }
        public string Decrypting(string cipher, object _key)
        {
            var output = "";
            string key = (string)_key;

            int[] keyArr = new int[cipher.Length];
            if (key.Length != 0)
            {
                for (int i = 0; i < keyArr.Length; i++)
                {
                    keyArr[i] = (int)key[i % key.Length] - 1040;
                    output += tabulaRecta[0][Array.IndexOf(tabulaRecta[keyArr[i]], cipher[i])];
                }           
            }
            return output;
        }
        public (string text, string cipherKey) Breaking(string cipher)
        {
            var key = BreakingFriedman(cipher);
            return (Decrypting(cipher, key), key);
        }
        public string BreakingFriedman(string cipher)
        {
            var shiftedTexts = new List<List<string>>();
            for (int s = 0; s < 50; s++)
            {
                shiftedTexts.Add(new List<string>());
                for (int i = 0; i <= s; i++)
                {
                    string text = "";
                    for (int k = i; k < cipher.Length; k += s + 1)
                        text += cipher[k];
                    shiftedTexts[s].Add(text);
                }
                if (shiftedTexts[s].Average(n => GetСoincidenceIndex(n)) > 0.05)
                {
                    var output = "";
                    shiftedTexts[s].ForEach(n => output += cyrillicAlphabet[Convert.ToInt32(caesarCipher.Breaking(n).cipherKey)]);
                    return output;
                }
            }
            return "Количество символов в ключе более 50";
        }
        public int BreakingKasiski(string cipher)
        {
            throw new NotImplementedException();
        }
        public static double GetСoincidenceIndex(string text)
        {
            double index = 0;
            List<char> letters = text.ToHashSet().ToList();
            foreach (var l in letters)
            {
                var cc = text.CharCount(l);
                index += cc * (cc - 1);
            }
            return index / (double)(text.Count() * text.Count() - 1);
        }
        private char[][] GetTabulaRecta()
        {
            var linkedAlph = GetLinkedAlphabet();
            char[][] tabulaRecta = new char[linkedAlph.Count][];
            for (int i = 0; i < tabulaRecta.Length; i++)
            {
                tabulaRecta[i] = linkedAlph.ToArray();
                linkedAlph.AddLast(linkedAlph.First.Value);
                linkedAlph.Remove(linkedAlph.First);
            }
            return tabulaRecta;
        }
        private LinkedList<char> GetLinkedAlphabet()
        {
            var la = new LinkedList<char>();
            la.AddLast('А');
            la.AddLast('Б');
            la.AddLast('В');
            la.AddLast('Г');
            la.AddLast('Д');
            la.AddLast('Е');
            la.AddLast('Ж');
            la.AddLast('З');
            la.AddLast('И');
            la.AddLast('Й');
            la.AddLast('К');
            la.AddLast('Л');
            la.AddLast('М');
            la.AddLast('Н');
            la.AddLast('О');
            la.AddLast('П');
            la.AddLast('Р');
            la.AddLast('С');
            la.AddLast('Т');
            la.AddLast('У');
            la.AddLast('Ф');
            la.AddLast('Х');
            la.AddLast('Ц');
            la.AddLast('Ч');
            la.AddLast('Ш');
            la.AddLast('Щ');
            la.AddLast('Ъ');
            la.AddLast('Ы');
            la.AddLast('Ь');
            la.AddLast('Э');
            la.AddLast('Ю');
            la.AddLast('Я');
            return la;
        }
    }
}
