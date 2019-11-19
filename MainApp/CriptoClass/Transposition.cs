using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;

namespace CriptoClass
{
    /// <summary>
    /// шифр перестановки
    /// </summary>
    class Transposition : Interfase_criptoelements<int[,]>//TODO: понять, как написать красиво
    {
        public string Code(WordAndKey<int[,]> element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);//TODO: может стоит объединить это в отдельный статический класс?
            var keyLitera = new int[element.Key.GetLength(1)];
            var buffkey= new int[element.Key.GetLength(1)];
            string result = "";
            int i = 0;
            foreach (var n in numberLitera)
            {
                result += Convert.ToString(FindValue.Findvalue((n + keyLitera[i]) % Languege.z));
                if (i==keyLitera.Length)
                    for (int j=0;i< keyLitera.Length;j++)
                        buffkey[j]=
            }

        }

        public string Decode(WordAndKey<int[,]> element)
        {
            throw new NotImplementedException();
        }

        int sequence(int[,] coefficients)
    }
}
