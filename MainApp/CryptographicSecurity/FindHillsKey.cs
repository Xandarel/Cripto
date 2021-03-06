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
        /// <summary>
        /// взлом ключа по открытому тексту и зашифрованному тексту
        /// </summary>
        /// <param name="word">открытый текст</param>
        /// <param name="cipher">зашифрованный текст</param>
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
                if (period > cipher.Length / period)
                    continue;
                var a = new double[period, period];
                var b = new double[period];
                var gausMatrix = new double[period + 1, period+2]; //Почему +2? один доп столбец-матрца b, другая - сам ответ. 
                for (int i=0; i<period;i++)
                {
                    var cNposition = i % period;//cNposition=cipherNumber position;
                    for (int y = 0; y < period + 1; y++)
                    {
                        var additionalCounter = y;
                        for (int x = 0; x < period+2; x++)
                        {
                            if (x + y < period + additionalCounter)
                                gausMatrix[y, x] = wordNumber[x + y+ additionalCounter];
                            else if (x + y == period + additionalCounter)
                                gausMatrix[y, x] = 1;
                            else
                                gausMatrix[y, x] = cipherNumber[cNposition];
                        }
                        cNposition += period;
                    }
                    LinearEquationSolver.Solve(gausMatrix);

                    for (var pos = 0; pos < period; pos++)
                    {
                        if (gausMatrix[pos, period + 1] - (int)gausMatrix[pos, period + 1] == 0)
                            a[i, pos] = (gausMatrix[pos, period + 1] + Languege.z) % Languege.z;
                        else
                        {
                            var workElement = Math.Round(gausMatrix[pos, period + 1], 2);
                            var multiplication = workElement.ToString().Split('.', ',').ToArray()[1].Length;
                            a[i, pos] = FindQuotientInRing(Math.Round(workElement * Math.Pow(10, multiplication) % Languege.z,0),
                                        Math.Pow(10, multiplication));
                        }
                    }
                    if (gausMatrix[period, period + 1] - (int)gausMatrix[period, period + 1] == 0)
                        b[i] = (gausMatrix[period, period + 1] + Languege.z) % Languege.z;
                    else
                    {
                        var workElement = Math.Round(gausMatrix[period, period + 1], 2);
                        var multiplication = workElement.ToString().Split('.', ',').ToArray()[1].Length;
                        b[i] = FindQuotientInRing(workElement * Math.Pow(10, multiplication) + Languege.z,
                                    Math.Pow(10, multiplication));
                    }
                }
                Ansver.Add(Matrix<double>.Build.DenseOfArray(a));
                Ansver.Add(Matrix<double>.Build.DenseOfColumnVectors(Vector<double>.Build.DenseOfArray(b)));
            }
        }
        public void FindKey(int length, string cipher)
        {
            //TODO: реелизовать взлом хилла, когда известен только шифр и длинна матрицы
        }
        List<int> PossiblePeriod(int wLength,int cLength)
        {
            var result = new List<int>();
            for (int i=2;i<= cLength / 2;i++)
                if (cLength % i == 0)
                    result.Add(i);
            result.Add(cLength);
            return result;
        }

        private static double FindQuotientInRing(double dividend, double divider)
        {
            double result = 0;
            for (var a = 0; a < Languege.z; a++)
                if (((divider * a) % Languege.z) == 1)
                {
                    result = a;
                    break;
                }
            return (dividend * result)%Languege.z;
        }
    }
}
