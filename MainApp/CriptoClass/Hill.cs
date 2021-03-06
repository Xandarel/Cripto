﻿using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Criptoclass;

namespace CriptoClass
{
    public class Hill : Interfase_criptoelements<List<Matrix<double>>>
    {
        public string Code(WordAndKey<List<Matrix<double>>> element)
        {
            if (element.Key[0].Determinant() == 0)
            {
                element.Encoded = "-1";
                return element.Encoded;
            }
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var n = element.Key[0].ToArray().GetLength(0);
            while (numberLitera.Count % n != 0)
                    numberLitera.Add(0);
            var start = 0;
            for (var i=n; i<=numberLitera.Count;i+=n)
            {
                var buff=new double[i - start,1];
                for (var j = 0; j < i - start; j++)//разделение массива на блоки длинны n
                    buff[j,0] = numberLitera[start+j];
                var matrix = Matrix<double>.Build.DenseOfArray(buff);
                matrix = element.Key[0] * matrix + element.Key[1];
                for (var t=0;t<matrix.RowCount;t++)
                    element.Encoded = Convert.ToString(FindValue.Findvalue(Convert.ToInt32(matrix[t,0] % Languege.z)));
                start = i;
            }
            return element.Encoded;
        }

        public string Decode(WordAndKey<List<Matrix<double>>> element)
        {
            var keyPosition = 0;
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var n = element.Key[0].ToArray().GetLength(0);
            var start = 0;
            for (var i = n; i <= numberLitera.Count; i += n)
            {
                var buff = new double[i - start, 1];
                for (var j = 0; j < i - start; j++)//разделение массива на блоки длинны n
                    buff[j, 0] = numberLitera[start + j];
                var matrix = Matrix<double>.Build.DenseOfArray(buff);
                var inverse = InverseMatrix.Normalization(element.Key[keyPosition++%element.Key.Count].Inverse());
                matrix =inverse * (matrix - element.Key[keyPosition++ % element.Key.Count]);
                for (var t = 0; t < matrix.RowCount; t++)
                    element.Encoded = Convert.ToString(FindValue.Findvalue(Convert.ToInt32(matrix[t, 0]) % Languege.z));
                start = i;
            }
            return element.Encoded;
        }
        public string Code(WordAndKey<List<Matrix<double>>> element, List<int> sequence)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var n = element.Key[0].ToArray().GetLength(0);
            while (numberLitera.Count % n != 0)
                numberLitera.Add(0);
            var start = 0;
            for (var i = n; i <= numberLitera.Count; i += n)
            {
                var dinamicMatrix = Generate.ModifiedHillMatrix(sequence, n);
                var buff = new double[i - start, 1];
                for (var j = 0; j < i - start; j++)//разделение массива на блоки длинны n
                    buff[j, 0] = numberLitera[start + j];
                var matrix = Matrix<double>.Build.DenseOfArray(buff);
                //var inverseMatrix = InverseMatrix.Inverse_Matrix(element.Key[0]); это в декодирование?
                matrix = dinamicMatrix[0]* element.Key[0] * matrix + dinamicMatrix[1];
                element.Key.Add(dinamicMatrix[0]);//данные элементы необходимы для дешифрования. иначе расшифровать шифр будет невозможно
                element.Key.Add(dinamicMatrix[1]);//их индексы в списке ключей будут начинаться с 2. 0-квадратная матрица, 1-базовый вектор столбец.
                for (var t = 0; t < matrix.RowCount; t++)
                    element.Encoded = Convert.ToString(FindValue.Findvalue(Convert.ToInt32(matrix[t, 0] % Languege.z)));
                start = i;
            }
            element.Key.RemoveRange(0, 2);
            return element.Encoded;
        }
    }
}
