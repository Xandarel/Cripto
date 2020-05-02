using System;
using System.Collections.Generic;
using System.Text;
using NHunspell;
using CriptoClass;
using Criptoclass;

namespace CryptographicSecurity
{
    public class FindPermutationKey
    {
        public List<int> Key { get; } = new List<int>();
        public void FindKey(string text)
        {
            for (var del=2;del<=text.Length/2;del++)
            {
                if (text.Length % del != 0)
                    continue;
                else
                {
                    var possiblePermutations = SetTransposition(new int[del], 0, del);
                    foreach (var perm in possiblePermutations)
                    {
                        var block = 0;
                        var permIndex = 0;
                        var decryption = new char[text.Length];
                        for (var w = 0; w < text.Length; w++)
                        {
                            decryption[w] = text[perm[permIndex] + block];
                            permIndex++;
                            if ((w + 1) % del == 0 && w != 0)
                                block+=del;
                            if (permIndex == perm.Length)
                                permIndex = 0;
                        }
                        var stringDecryption = decryption.ToString();
                        if (Languege.dictionary.ContainsKey('А')) //Русский язык
                            using (var hunspell = new Hunspell("ru_RU.aff", "ru_RU.dic"))
                            {
                                //TODO: реализовать
                                //https://www.codeproject.com/Articles/33658/NHunspell-Hunspell-for-the-NET-platform
                            }
                        else
                            using (var hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                            {
                                //https://www.codeproject.com/Articles/33658/NHunspell-Hunspell-for-the-NET-platform
                            }
                    }
                }
            }
        }

        private List<int[]> SetTransposition(int[] a, int n, int l)
        {
            var result = new List<int[]>();
            for (int i = 0; i < l; i++)
            {
                int j;
                for (j = 0; j < n; j++)
                    if (a[j] == i) break;
                if (j == n)
                {
                    a[n] = i;
                    if (n < l - 1)
                        result.AddRange(SetTransposition(a, n + 1, l));
                    else
                    {
                        var ListElement = new int[l];
                        a.CopyTo(ListElement, 0);
                        result.Add(ListElement);
                    }
                }
            }
            return result;   
        }

    }
}
