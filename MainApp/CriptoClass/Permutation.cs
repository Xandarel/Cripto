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
            var delta = 0;
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var keyLength = element.Key.GetLength(1);
            if (numberLitera.Count % keyLength != 0)
                delta = 1;
            var array = new double[numberLitera.Count / keyLength + delta, keyLength];
            var count = 0;
            for (var y = 0; y <numberLitera.Count/keyLength; y++)
                for (var x = 0; x < keyLength; x++)
                {
                    array[y, x] = numberLitera[y * keyLength + x];
                    count++;
                }
            if (count < numberLitera.Count)
                for (var x = 0; x < numberLitera.Count-count; x++)
                    array[(numberLitera.Count / keyLength), x] = numberLitera[count + x];
            var matrixArray = Matrix<double>.Build.DenseOfArray(array);
            var ansverMatrix = DenseMatrix.Create((numberLitera.Count / keyLength) + delta, keyLength, 0);
            for (var start=0;start<keyLength;start++)
            {
                var column = matrixArray.Column(element.Key[0, start]);
                ansverMatrix.SetColumn(element.Key[1, start], column.ToArray());
            }

            for (var x = 0; x < keyLength; x++)
                for (var y = 0; y < (numberLitera.Count / keyLength) + delta; y++)
                    element.Encoded= Convert.ToString(FindValue.Findvalue(Convert.ToInt32(ansverMatrix[y,x]) % Languege.z));
            return element.Encoded;
        }

        public string Decode(WordAndKey<int[,]> element)
        {
            var delta = 0;
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var keyLength = element.Key.GetLength(1);
            if (numberLitera.Count % keyLength != 0)
                delta = 1;
            var array = new double[numberLitera.Count / keyLength + delta, keyLength];
            var count = 0;

            for (var x = 0; x < keyLength; x++)
                for (var y = 0; y < numberLitera.Count / keyLength; y++)
                {
                    array[y,x] = numberLitera[count];
                    count++;
                }

            if (count < numberLitera.Count)
                for (var x = 0; x < numberLitera.Count - count; x++)
                    array[x, (numberLitera.Count / keyLength)] = numberLitera[count + x];

            var matrixArray = Matrix<double>.Build.DenseOfArray(array);
            var ansverMatrix = DenseMatrix.Create((numberLitera.Count / keyLength) + delta, keyLength, 0);
            for (var start = 0; start < keyLength; start++)
            {
                var column = matrixArray.Column(element.Key[1, start]);
                ansverMatrix.SetColumn(element.Key[0, start], column.ToArray());
            }
            for (var y = 0; y < (numberLitera.Count / keyLength) + delta; y++)
                for (var x = 0; x < keyLength; x++)
                    element.Encoded = Convert.ToString(FindValue.Findvalue(Convert.ToInt32(ansverMatrix[y,x]) % Languege.z));
            return element.Encoded;
        }
    }
}
