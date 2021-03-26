﻿using System;
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
            //Console.WriteLine($"{BreakingKasiski(cipher)} {BreakingKasiski2(cipher)} {BreakingFriedman(cipher)}");
            
            // BreakingKasiski, BreakingKasiski2 или BreakingFriedman.
            var key = BreakingFriedman(cipher); 
            return (Decrypting(cipher, key), key);
        }
        private string BreakingFriedman(string cipher)
        {
            var shiftedTexts = new List<List<string>>();
            for (int s = 0; s < 50; s++)
            {
                shiftedTexts.Add(GetShiftedText(cipher, s));              
                if (shiftedTexts[s].Average(n => GetСoincidenceIndex(n)) > 0.05)
                {
                    var output = "";
                    shiftedTexts[s].ForEach(n => output += cyrillicAlphabet[Convert.ToInt32(caesarCipher.Breaking(n).cipherKey)]);
                    return output;
                }
            }
            return "0"; 
        }
        private List<string> GetShiftedText(string cipher, int shift)
        {
            var shiftedText = new List<string>();
            for (int i = 0; i <= shift; i++)
            {
                string text = "";
                for (int k = i; k < cipher.Length; k += shift + 1)
                    text += cipher[k];
                shiftedText.Add(text);
            }
            return shiftedText;
        }
        private double GetСoincidenceIndex(string text)
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
        private Dictionary<string, List<int>> GetRepeatedSubstrings(string text, int substrRepeatCount = 2, int substrMaxLenght = 5, int substrMinLenght = 2)
        {
            var occ = new Dictionary<string, List<int>>();
            for (int i = 0; i < text.Length; i++)
                for (int j = substrMinLenght; j <= substrMaxLenght && (i - j) > 0; j++)
                {
                    string str = text.Substring(i - j, j);
                    if (occ.ContainsKey(str))
                        occ[str].Add(i - j);
                    else
                        occ.Add(str, new List<int> { i - j });
                }
            return occ.Where(r => r.Value.Count >= substrRepeatCount)
                      .ToDictionary(r => r.Key, r => r.Value);
        }
        // Greatest common divisor.
        // Наибольший общий делитель.
        private int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            else
            {
                var min = a < b ? a : b;
                var max = a > b ? a : b;
                return GCD(max - min, min);
            }
        }
        private string BreakingKasiski(string cipher)
        {
            var longerRepeat = GetRepeatedSubstrings(cipher, 8, 3, 3)
                .Aggregate((l, r) => l.Key.Length > r.Key.Length ? l : r).Value;
            var gcds = new Dictionary<int, int>();
            for (int i = 0; i < longerRepeat.Count - 2; i++)
            {
                int gcd = GCD(longerRepeat[i + 1] - longerRepeat[i], longerRepeat[i + 2] - longerRepeat[i + 1]);
                if (gcd > 1)
                    if (gcds.ContainsKey(gcd))
                        gcds[gcd]++;
                    else
                        gcds.Add(gcd, 1);
            }
            var keyLenght = gcds.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            return GetCipherKey(cipher, keyLenght);
        }
        private string BreakingKasiski2(string cipher)
        {
            var repeatedSubstrs = GetRepeatedSubstrings(cipher);
            var gcds = new Dictionary<int, int>();
            foreach (var sub in repeatedSubstrs.Values)
                for (int i = 0; i < sub.Count - 2; i++)
                {
                    int gcd = GCD(sub[i + 1] - sub[i], sub[i + 2] - sub[i + 1]);
                    if (gcd > 1)
                        if (gcds.ContainsKey(gcd))
                            gcds[gcd]++;
                        else
                            gcds.Add(gcd, 1);
                }
            var keyLenght = gcds.Aggregate((l, r) => l.Value * l.Key > r.Value * r.Key ? l : r).Key;
            return GetCipherKey(cipher, keyLenght);
        }
        private string GetCipherKey(string cipher, int keyLenght)
        {
            var output = "";
            var shiftedTexts = GetShiftedText(cipher, keyLenght - 1);
            shiftedTexts.ForEach(n => output += cyrillicAlphabet[Convert.ToInt32(caesarCipher.Breaking(n).cipherKey)]);
            return output;
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
