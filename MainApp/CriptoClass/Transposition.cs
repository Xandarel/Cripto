using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;

namespace CriptoClass
{
    /// <summary>
    /// шифр перестановки
    /// </summary>
    public class Transposition : Interfase_criptoelements<int[,]>//TODO: понять, как написать красиво
    {
        public string Code(WordAndKey<int[,]> element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);//TODO: может стоит объединить это в отдельный статический класс?
            var keyLitera = new LimitedSizeStack<int>(element.Key.GetLength(1));
            string result = "";
            for (var i=0;i< element.Key.GetLength(1); i++)
                if (i < element.Key.GetLength(1))
                    keyLitera.Push(element.Key[1, i]);
            //foreach (var n in numberLitera)
            //result += Convert.ToString(FindValue.Findvalue((n + keyLitera[i]) % Languege.z));

            return "";
        }

        public string Decode(WordAndKey<int[,]> element)
        {
            throw new NotImplementedException();
        }

        //int sequence(int[,] coefficients, int[] array)
        //{

        //}
    }
}
