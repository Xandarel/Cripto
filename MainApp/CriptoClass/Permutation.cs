using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CriptoClass
{
    public class Permutation : Interfase_criptoelements<int[,]>
    {
        public string Code(WordAndKey<int[,]> element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var keyLength = element.Key.GetLength(1);
            var array = new double[numberLitera.Count/keyLength, keyLength];
            for (var y = 0; y < numberLitera.Count / keyLength; y++)
                for (var x = 0; x < keyLength; x++)
                    array[y,x] = numberLitera[y * keyLength + x];
            var matrixArray = Matrix<double>.Build.DenseOfArray(array);
            var ansverMatrix = DenseMatrix.Create(keyLength, keyLength, 0);
            for (var start=0;start<keyLength;start++)
            {
                var column = matrixArray.Column(element.Key[0, start]);
                ansverMatrix.SetColumn(element.Key[1, start], column.ToArray());
            }
            for (var y = 0; y < keyLength; y++)
                for (var x = 0; x < keyLength; x++)
                    element.Encoded= Convert.ToString(FindValue.Findvalue(Convert.ToInt32(ansverMatrix[x,y]) % Languege.z));
            return element.Encoded;
        }

        public string Decode(WordAndKey<int[,]> element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var keyLength = element.Key.GetLength(1);
            var array = new double[keyLength, keyLength];
            for (var y = 0; y < keyLength; y++)
                for (var x = 0; x < keyLength; x++)
                    array[y, x] = numberLitera[y * keyLength + x];
            var matrixArray = Matrix<double>.Build.DenseOfArray(array);
            var ansverMatrix = DenseMatrix.Create(keyLength, keyLength, 0);
            for (var start = 0; start < keyLength; start++)
            {
                var column = matrixArray.Column(element.Key[1, start]);
                ansverMatrix.SetColumn(element.Key[0, start], column.ToArray());
            }
            for (var y = 0; y < keyLength; y++)
                for (var x = 0; x < keyLength; x++)
                    element.Encoded = Convert.ToString(FindValue.Findvalue(Convert.ToInt32(ansverMatrix[x, y]) % Languege.z));
            return element.Encoded;
        }
    }
}
