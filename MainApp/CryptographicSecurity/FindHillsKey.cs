﻿using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using CriptoClass;
using Criptoclass;
using System.Linq;

namespace CryptographicSecurity
{
    public class FindHillsKey
    {
        public List<Matrix<double>> Ansver { get; } = new List<Matrix<double>>();
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
                var a = new double[period, period];
                var b = new double[period];
                var gausMatrix = new double[period + 2, period+1]; //Почему +2? один доп столбец-матрца b, другая - сам ответ. 
                for (int i=0; i<period;i++)
                {
                    var cNposition = i % period;//cNposition=cipherNumber position;
                    for (int y = 0; y < period + 1; y++)
                    {
                        for (int x = 0; x < period; x++)
                        {
                            if (x + y < period)
                                gausMatrix[y, x] = wordNumber[x + y];
                            else if (x + y == period)
                                gausMatrix[y, x] = 1;
                            else
                                gausMatrix[y, x] = cipherNumber[cNposition];
                        }
                        cNposition += period;
                    }
                    LinearEquationSolver.Solve(gausMatrix);

                    for (var pos = 0; pos < period; pos++)
                        a[i, pos] = (gausMatrix[pos, period+1]+Languege.z)%Languege.z;
                    b[i] = (gausMatrix[period + 1, period + 1]+Languege.z)%Languege.z;
                }
                Ansver.Add(Matrix<double>.Build.DenseOfArray(a));
                Ansver.Add(Matrix<double>.Build.DenseOfColumnVectors(Vector<double>.Build.DenseOfArray(b)));
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
