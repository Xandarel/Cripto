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
                //Вопрос. Как теперь перебрать все комбинации?
                var resultSubstring = analisSubstring.Select(x => BlockAnalysis(x)).ToArray();
                var ansverArray = new char[chiperText.Length];
                var changePosition = new List<int>();
                var ansPos = 0;
                for (int i=0;i<resultSubstring.Length;i++)
                {
                    if (resultSubstring[i].Count > 1)//если есть несколько вариантов этого блока
                        changePosition.Add(i);     //запомни где это может произойти
                    //for (var j = 0; j < resultSubstring[i][0].Length; j++)
                    foreach (var a in resultSubstring[i][0])
                    {
                        ansverArray[ansPos] = a;
                        ansPos += m;
                    }
                    ansPos = i + 1;
                }
                Add(ansverArray);
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

        private List<string> BlockAnalysis (string block)
        {
            var frequencyLetters = new Dictionary<char, double>();
            foreach (var libra in block)
                if (!frequencyLetters.ContainsKey(libra))
                    frequencyLetters.Add(libra, 1);
                else
                    frequencyLetters[libra] += 1;
            var maxValue = 0.0;
            var maxLibra=new List<char>();
            foreach (var k in frequencyLetters.Keys) 
            {
                if (frequencyLetters[k] > maxValue)
                {
                    maxLibra.Clear();
                    maxLibra.Add(k);
                    maxValue = frequencyLetters[k];
                }
                else if (frequencyLetters[k] == maxValue)
                    maxLibra.Add(k);
            }
            var delta = new List<int>();
            foreach (var l in maxLibra)
                delta.Add(Math.Abs(Languege.dictionary[l] - Languege.dictionary['О']));
            var decodeLetter = new List<string>();
            for (int i = 0; i < delta.Count; i++)
            {
                decodeLetter.Add("");
                foreach (var b in block)
                {
                    var decodePosition = Languege.dictionary[b] - delta[i];
                    decodeLetter[i] += FindValue.Findvalue(decodePosition);
                }
            }
            return decodeLetter;
        }

        private void Add(char[] text)
        {
            var stringAns = "";
            foreach (var a in text)
                stringAns += a;
            key.Add(stringAns.ToLower());
        }
    }
}


  //if (resultSubstring[i].Count > 1)
  //                      changePosition.Add(i);
  //                  for (var j=0;j<resultSubstring[i][0].Length;j++)
  //                  {
  //                      ansverArray[ansPos] = resultSubstring[i][0][j];
  //                      ansPos += m;
  //                  }
  //                  ansPos = i + 1;