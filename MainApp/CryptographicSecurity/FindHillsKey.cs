using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using CriptoClass;

namespace CryptographicSecurity
{
    public class FindHillsKey
    {
        private List<Matrix<double>> ansver=new List<Matrix<double>>();
        public void FindKey(string word, string cipher)
        {
            var checkPeriof = PossiblePeriod(word.Length, cipher.Length);
            var wordNumber = Converter.ConvertWordToCode(word.ToUpper());
            var cipherNumber = Converter.ConvertWordToCode(cipher.ToUpper());

        }
        List<int> PossiblePeriod(int wLength,int cLength)
        {
            var end = wLength < cLength ? cLength : wLength;
            var result = new List<int>();
            for (int i=2;i<=end/2;i++)
                if (end % i == 0)
                    result.Add(i);
            result.Add(end);
            return result;
        }
    }
}
