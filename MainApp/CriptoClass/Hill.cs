using System;
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
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var n = element.Key[0].ToArray().GetLength(0);
            var start = 0;
            for (var i=n; i<=numberLitera.Length;i+=n)
            {
                if (i >= numberLitera.Length)
                    i = numberLitera.Length;
                var buff=new double[i - start,1];
                for (var j = 0; j < i - start; j++)//разделение массива на блоки длинны n
                    buff[j,0] = numberLitera[start+j];
                var matrix = Matrix<double>.Build.DenseOfArray(buff);
                matrix = element.Key[0] * matrix + element.Key[1];
                for (var t=0;t<matrix.RowCount;t++)
                    element.Encoded = Convert.ToString(FindValue.Findvalue(Convert.ToInt32(matrix[t,0] % Languege.z)));
                start = i;
            }
            return element.Encoded;//TODO: проверить, работает ли правильно
        }

        public string Decode(WordAndKey<List<Matrix<double>>> element)
        {
            throw new NotImplementedException();
        }
    }
}
