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
            //var buff= new LimitedSizeStack<int>(element.Key.GetLength(1));
            string result = "";
            for (var i=0;i< element.Key.GetLength(1); i++)
                    keyLitera.Push(element.Key[1, i]);
            foreach (var nL in numberLitera)
            {
                result+= Convert.ToString(FindValue.Findvalue((nL + keyLitera.Pop()) % Languege.z));
                if (keyLitera.Count == 0)
                    sequence(element.Key, keyLitera);

            }

            return result;
        }

        public string Decode(WordAndKey<int[,]> element)
        {
            throw new NotImplementedException();
        }

        void sequence(int[,] coefficients, LimitedSizeStack<int> key)
        {
            key.Restore();
            for (int i = 0; i < coefficients.GetLength(1); i++)
            {
                int newElementSequence = 0;
                for (var j = 0; j < coefficients.GetLength(0); j++)
                    newElementSequence += coefficients[0, j] * key.Pop();
                key.Restore();
                key.Push(newElementSequence);
            }
        }
    }
}
