using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Criptoclass;

namespace CryptographicSecurity
{
    public class VigenereKey
    {
        private string key;
        public string GetKey => key;
        public void FindKey(string chiperText)
        {
            var repetitionPeriods = KasiskiMethod(chiperText);
            var nod = FindNOD(repetitionPeriods.ToArray());
            var k = 1;
            for (var m = nod; ; m = nod * k)
            {
                var analisSubstring = new string[m];
                for (var start = 0; start < m; start++)
                {
                    for (var pos = start; pos < chiperText.Length; pos += m)
                        analisSubstring[start] += chiperText[pos];
                }
            }
        }
        private List<int> KasiskiMethod(string chiperText)
        {
            var result = new List<int>();
            var segmentInText = new Dictionary<string, int>();
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

        private int FindNOD(int[] periods)
        {
            var nod = periods.Min();
            while (true)
            {
                long temp = nod;
                foreach (var number in periods)
                {
                    var tDiv = number / nod;
                    if (!(tDiv > 0 && number % nod == 0))
                        nod = number / (tDiv + 1);
                }
                if (temp == nod) break;
            }
            return nod;
        }

        private void BlockAnalysis (string block)
        {
            var frequencyLetters = new Dictionary<char, double>();
            foreach (var libra in block)
                if (!frequencyLetters.ContainsKey(libra))
                    frequencyLetters.Add(libra, 1);
                else
                    frequencyLetters[libra] += 1;
            foreach (var k in frequencyLetters.Keys)
                frequencyLetters[k] = frequencyLetters[k] * 100 / block.Length;
        }
    }
}
