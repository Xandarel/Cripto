using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Criptoclass;

namespace CriptoClass
{
    class Hill : Interfase_criptoelements<List<Matrix<int>>>
    {
        public string Code(WordAndKey<List<Matrix<int>>> element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var n = element.Key[0].ToArray().GetLength(0);
            var start = 0;
            for (var i=n; i<numberLitera.Length;i+=n)
            {
                if (i > numberLitera.Length)
                    i = numberLitera.Length;
                var buff=new int[i - start,1];
                for (var j = 0; j < i - start; j++)//разделение массива на блоки длинны n
                    buff[j,0] = numberLitera[start+j];
                var matrix = Matrix<int>.Build.DenseOfArray(buff);
                matrix = (matrix + element.Key[1]) * element.Key[0];
                for (var t=0;t<matrix.RowCount;t++)
                    element.Encoded= element.Encoded = Convert.ToString(FindValue.Findvalue(matrix[t,0]) % Languege.z);
            }
            return element.Encoded;//TODO: проверить, работает ли правильно
        }

        public string Decode(WordAndKey<List<Matrix<int>>> element)
        {
            throw new NotImplementedException();
        }
    }
}
