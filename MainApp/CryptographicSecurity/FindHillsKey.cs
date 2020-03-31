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
            var checkPeriod = PossiblePeriod(word.Length, cipher.Length); //Все возможные периоды размера ключа
            var wordNumber = Converter.ConvertWordToCode(word.ToUpper());
            var cipherNumber = Converter.ConvertWordToCode(cipher.ToUpper());
            #region пояснения
            //размерность матрицы=количество систем уравнений
            //длинна зашифрованного текста/размерность матрицы=количество уравнений в системах
            //размерность матрицы+1 = количество неизвестных, где +1=матрица b
            //если количество уравнений !=количеству неизвестных, то систему не решить.
            #endregion
            foreach (var period in checkPeriod)
            {
                if (period != cipher.Length / period - 1)
                    continue;
                
            }
        }
        List<int> PossiblePeriod(int wLength,int cLength)
        {
            var result = new List<int>();
            for (int i=2;i<= wLength / 2;i++)
                if (wLength % i == 0)
                    result.Add(i);
            result.Add(wLength);
            return result;
        }
    }
}
