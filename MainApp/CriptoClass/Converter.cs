using Criptoclass;
using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CriptoClass
{
   public static class Converter
    {
        public static List<int> ConvertWordToCode(string text)
        {

            var numberLitera = new List<int>();
            foreach (var litera in text.ToUpper()) // Перевод слова в код
                numberLitera.Add( Languege.dictionary[litera]);
            return numberLitera;
        }

        public static string ConvertArrayToString(char[] array)
        {
            string ans = "";
            foreach (var a in array)
                ans += a;
            return ans;
        }
    }
}
