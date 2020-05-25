using System;
using System.Collections.Generic;
using System.Text;
using CriptoClass;
using Criptoclass;
using WeCantSpell.Hunspell;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CryptographicSecurity
{
    public class FindPermutationKey
    {
        public List<int[]> Key { get; } = new List<int[]>();
        public void FindKey(string cText, string oText)
        {
            var numberLitera = Converter.ConvertWordToCode(cText);
            for (var del=2;del<=cText.Length;del++)
            {
                if (cText.Length % del != 0)
                    continue;
                else
                {
                    var possiblePermutations = SetTransposition(new int[del], 0, del);
                    foreach (var perm in possiblePermutations)
                    {
                        var array = new double[cText.Length / del, del];
                        var pos = 0;
                        for (var x = 0; x < del; x++)
                            for (var y=0;y< cText.Length / del;y++)
                            {
                                array[y, x] = numberLitera[pos];
                                pos++;
                            }
                        var matrixArray = Matrix<double>.Build.DenseOfArray(array);
                        var ansverMatrix = DenseMatrix.Create(cText.Length / del, del, 0);
                        pos = 0;
                        foreach (var p in perm)
                        {
                            var column = matrixArray.Column(p);
                            ansverMatrix.SetColumn(pos, column.ToArray());
                            pos++;
                        }
                        string ans = "";
                        for (var y = 0; y < cText.Length / del; y++)
                            for (var x = 0; x < del; x++)
                                ans += Convert.ToString(FindValue.Findvalue(Convert.ToInt32(ansverMatrix[y, x]) % Languege.z));
                        if (ans.Contains(oText.ToUpper()))
                            Key.Add(perm);
                        #region
                        //var block = 0;
                        //var permIndex = 0;
                        //var decryption = new char[cText.Length];
                        //for (var w = 0; w < cText.Length; w++)
                        //{
                        //    decryption[w] = cText[perm[permIndex] + block];
                        //    permIndex++;
                        //    if ((w + 1) % del == 0 && w != 0)
                        //        block+=del;
                        //    if (permIndex == perm.Length)
                        //        permIndex = 0;
                        //}
                        ////TODO: Сделать из этого что-то нормальное
                        //var stringDecryption = Converter.ConvertArrayToString(decryption);
                        //if (stringDecryption.Contains(oText))
                        //    Key.Add(perm);
                        //if (Languege.dictionary.ContainsKey('А')) //Русский язык
                        //{
                        //    var dictionary = WordList.CreateFromFiles(@"Russian.dic", @"Russian.aff");
                        //    var suggestions = dictionary.Suggest(stringDecryption);
                        //    foreach (var s in suggestions)
                        //        Console.WriteLine(s);
                        //}
                        //else
                        //{

                        //}
                        #endregion
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
