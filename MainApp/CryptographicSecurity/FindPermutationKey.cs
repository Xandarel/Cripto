using System;
using System.Collections.Generic;
using System.Text;
using CriptoClass;
using Criptoclass;
using WeCantSpell.Hunspell;

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
                        //TODO: Сделать из этого что-то нормальное
                        var stringDecryption = Converter.ConvertArrayToString(decryption);
                        if (Languege.dictionary.ContainsKey('А')) //Русский язык
                        {
                            var dictionary = WordList.CreateFromFiles(@"Russian.dic", @"Russian.aff");
                            var suggestions = dictionary.Suggest(stringDecryption);
                            foreach (var s in suggestions)
                                Console.WriteLine(s);
                        }
                        else
                        {

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
