using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

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
                var buff=new int[n - start];
                for (var j = start; j < n; j++)
                    buff[j] = numberLitera[j];

            }
        }

        public string Decode(WordAndKey<List<Matrix<int>>> element)
        {
            throw new NotImplementedException();
        }
    }
}
