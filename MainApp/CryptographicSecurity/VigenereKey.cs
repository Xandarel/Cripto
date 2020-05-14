using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Criptoclass;
using CriptoClass;

namespace CryptographicSecurity
{
    public class VigenereKey
    {
        private List<string> key=new List<string>();
        public List<string> GetKey => key;
        public void FindKey(string chiperText)
        {
            chiperText = chiperText.ToUpper();
            var repetitionPeriods = KasiskiMethod(chiperText);
            if (repetitionPeriods.Count == 0)
                Console.WriteLine("Невозможно найти период. Невозможно взломать ключ");
            else { 
            var nod = FindNOD(repetitionPeriods.ToArray());
            var k = 1;
                for (var m = nod; ; m = nod * k)
                {
                    if (m > chiperText.Length / m)
                        break;
                    char[,] strings = new char[chiperText.Length / m + 1, m];
                    for (int i = 0; i < chiperText.Length; i++)
                    {
                        int ii = i / m;
                        int ij = i - (ii * m);

                        strings[ii, ij] = chiperText[i];
                    }
                    var paswords = new List<string>();
                    paswords.Add("");
                    for (int i = 0; i < m; i++)
                    {
                        Dictionary<char, int> dict = new Dictionary<char, int>();

                        for (int j = 0; j < (chiperText.Length / m) + 1; j++)
                            if (dict.ContainsKey(strings[j, i]))
                                dict[strings[j, i]]++;
                            else
                                dict.Add(strings[j, i], 1);

                        var sortict = dict.OrderByDescending(x => x.Value)
                                          .ToDictionary(x => x.Key, x => x.Value);
                        var maxValue = sortict.Values.Max();
                        var positionCandidat = new List<char>();

                        char sy = Languege.z == 33 ? 'О' : 'E';
                        foreach (var kvp in sortict)
                        {
                            if (kvp.Value < maxValue)
                                break;
                            else
                                positionCandidat.Add(kvp.Key);
                        }
                        if (positionCandidat.Count > 1)
                        {
                            var bufList = new List<string>(paswords);
                            for (var copy = 0; copy < positionCandidat.Count - 1; copy++)
                                paswords.AddRange(bufList);
                            var transition = paswords.Count / positionCandidat.Count;
                            var candidatElement = 0;
                            for (var pos = 0; pos < paswords.Count; pos++)
                            {
                                if (pos != 0 && pos % transition == 0)
                                    candidatElement++;
                                int res = Languege.dictionary[positionCandidat[candidatElement]] -
                                                   Languege.dictionary[sy];
                                paswords[pos] += FindValue.Findvalue(res + 1);
                            }
                        }
                        else
                        {
                            int res = Languege.dictionary[positionCandidat[0]] -
                                                  Languege.dictionary[sy];
                            for (var pos = 0; pos < paswords.Count; pos++)
                                paswords[pos] += FindValue.Findvalue(res);
                        }
                    }
                    foreach (var password in paswords)
                        Add(password);
                    k += 1;
                }
            }
        }
        private List<int> KasiskiMethod(string chiperText)
        {
            var result = new List<int>();
            var segmentInText = new Dictionary<string,int>();
            for (var i=0;i<chiperText.Length-3;i++)
            {
                var substring = chiperText.Substring(i, 3);
                if (!segmentInText.ContainsKey(substring))
                    segmentInText.Add(substring, i);
                else
                {
                    result.Add(i - segmentInText[substring]);
                    segmentInText[substring] = i;
                }
            }
            return result;
        }

        private int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        private int FindNOD(int[] periods)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int i = 0; i < periods.Length; i++)
                for (int j = i + 1; j < periods.Length; j++)
                {
                    int gc = GCD(periods[i], periods[j]);
                    if (gc > 1)
                        if (!pairs.ContainsKey(gc))
                            pairs.Add(gc, 1);
                        else
                            pairs[gc]++;
                }
            return pairs.Keys.Min();
        }
        private void Add(string text) => key.Add(text.ToLower());
    }
}