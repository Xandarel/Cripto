using System;
using System.Collections.Generic;
using System.Text;

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
