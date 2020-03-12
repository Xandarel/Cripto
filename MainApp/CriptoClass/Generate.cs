using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using Criptoclass;
using System.Text;

namespace CriptoClass
{
    public static class Generate
    {
        public static List<Matrix<double>> CreateKeysMatrix(int length)
        {
            Random rnd = new Random();
            var key = new List<Matrix<double>>();
            var first = new double[length, length];
            var second = new double[length, 1];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    first[i, j] = rnd.Next(0, Languege.z-1);
            for (int i = 0; i < length; i++)
                second[i,0]= rnd.Next(0, Languege.z - 1);
            key.Add(Matrix<double>.Build.DenseOfArray(first));
            key.Add(Matrix<double>.Build.DenseOfArray(second));
            return key;
        }

        public static  List<int> PseudorandomSequence(int[,] basisOfSequence)
        {
            var result = new List<int>();
            var generator = new LimitedSizeStack<int>(basisOfSequence.GetLength(1));
            for (var i = 0; i < basisOfSequence.GetLength(1); i++)
                generator.Push(basisOfSequence[1, i]);
            for (var i=0;i<100;i++)
            {
                result.Add( generator.PopFirst() % Languege.z);
                if (checkRepetition(result, basisOfSequence, i))
                {
                    result.RemoveRange(result.Count - basisOfSequence.GetLength(1), basisOfSequence.GetLength(1));
                    return result;
                }
                if (generator.Count == 0)
                    sequence(basisOfSequence, generator);
            }
            return result;
        }
        /// <summary>
        /// данная функция создает новый блок псевдослучайных элементов последовательности из предыдущих.
        /// в двумерном массиве ключа в первой строке хранится коефициент
        /// во второй значение
        /// коэфициент*значание=новый элемент
        /// </summary>
        /// <param name="coefficients"></param>
        /// <param name="key"></param>
        public static void sequence(int[,] coefficients, LimitedSizeStack<int> key)
        {
            key.Restore();
            for (int i = 0; i < coefficients.GetLength(1); i++)
            {
                int newElementSequence = 0;
                for (var j = 0; j <= coefficients.GetLength(0); j++)
                {
                    var multiplier = key.PopLast();
                    newElementSequence += coefficients[0, j] * multiplier;
                }
                key.Restore();
                key.Push(newElementSequence%Languege.z);
            }
        }
        static bool checkRepetition(List<int> result, int[,] basisOfSequence,int i)
        {
            if (i > basisOfSequence.GetLength(1))
            {
                int checkingForRepetition = 0;
                for (int check = 0; check < basisOfSequence.GetLength(1); check++)
                {
                    var secondPosition = result.Count - basisOfSequence.GetLength(1) + check;
                    if (result[check] == result[secondPosition])
                        checkingForRepetition++;
                    else
                    {
                        checkingForRepetition = 0;
                        break;
                    }
                }
                if (checkingForRepetition == basisOfSequence.GetLength(1))
                    return true;
                else return false;
            }
            else return false;
        }

        public static List<Matrix<double>> ModifiedHillMatrix(List<int> element, int range)
        {
            var matrix = new double[range, range];
            Random rnd = new Random();
            var key = new List<Matrix<double>>();
            int positionElement = 0;
            for (var y=0;y<range;y++)
                for(var x=0;x<range;x++)
                {
                    if (y == x)
                        matrix[y, x] = Languege.setOfReversibleElements[rnd.Next(0, Languege.setOfReversibleElements.Count)];
                    else if (y > x)
                        matrix[y, x] = 0;
                    else
                        matrix[y, x] = element[(positionElement++)%element.Count];
                }
            var second = new double[range, 1];
            for (int y=0;y<range;y++)
                second[y, 0] = rnd.Next(0, Languege.setOfReversibleElements.Count);
            key.Add(Matrix<double>.Build.DenseOfArray(matrix));
            key.Add(Matrix<double>.Build.DenseOfArray(second));
            return key;
        }
    }
}
