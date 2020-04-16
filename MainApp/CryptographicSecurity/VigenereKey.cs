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
            var nod = FindNOD(repetitionPeriods.ToArray());
            var k = 1;
            for (var m = nod;; m*=k )
            {
                if (m > chiperText.Length)
                    break;
                var analisSubstring = new string[m];
                for (var start = 0; start < m; start++)
                {
                    for (var pos = start; pos < chiperText.Length; pos += m)
                        analisSubstring[start] += chiperText[pos];
                }
                var resultSubstring = analisSubstring.Select(x => BlockAnalysis(x)).ToArray();
                var ansverList = new char[chiperText.Length];
                var ansPos = 0;
                for (int i = 0; i < resultSubstring.Length; i++)
                {
                    for (int j = 0; j < resultSubstring[i].Length; j++)
                    {
                        ansverList[ansPos] = resultSubstring[i][j];
                        ansPos += m;
                    }
                    ansPos=i+1;
                }
                var stringAns = "";
                foreach (var a in ansverList)
                    stringAns += a;
                key.Add(stringAns.ToLower());
                k += 1;
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

        private string BlockAnalysis (string block)//Могут происходить коллизии, когда несколько букв имеют маскмимальную длинну. Нужно перебрать все.
        {
            var frequencyLetters = new Dictionary<char, double>();
            foreach (var libra in block)
                if (!frequencyLetters.ContainsKey(libra))
                    frequencyLetters.Add(libra, 1);
                else
                    frequencyLetters[libra] += 1;
            var maxValue = 0.0;
            char maxLibra='О';
            foreach (var k in frequencyLetters.Keys) 
            {
                //frequencyLetters[k] = frequencyLetters[k] * 100 / block.Length;
                if (frequencyLetters[k] > maxValue)
                {
                    maxLibra = k;
                    maxValue = frequencyLetters[k];
                }
            }
            var delta = Math.Abs(Languege.dictionary[maxLibra] - Languege.dictionary['О']);
            string decodeLetter = "";
            foreach (var b in block)
            {
                var decodePosition = Languege.dictionary[b] - delta;
                decodeLetter += FindValue.Findvalue(decodePosition);
            }
            return decodeLetter;
        }
    }
}
