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
        public string Code(WordAndKey<int[,]> element)//TODO: понять, как реализовать в других системах исчисления
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);//TODO: может стоит объединить это в отдельный статический класс?
            var keyLitera = new LimitedSizeStack<int>(element.Key.GetLength(1));
            for (var i=0;i< element.Key.GetLength(1); i++)
                    keyLitera.Push(element.Key[1, i]);
            foreach (var nL in numberLitera)
            {
                element.Encoded = Convert.ToString(FindValue.Findvalue((nL + keyLitera.PopFirst()) % Languege.z));
                if (keyLitera.Count == 0)
                    sequence(element.Key, keyLitera);

            }
            return element.Encoded;
        }

        public string Decode(WordAndKey<int[,]> element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);//TODO: может стоит объединить это в отдельный статический класс?
            var keyLitera = new LimitedSizeStack<int>(element.Key.GetLength(1));
            for (var i = 0; i < element.Key.GetLength(1); i++)
                keyLitera.Push(element.Key[1, i]);
            foreach (var nL in numberLitera)
            {
                element.Encoded = Convert.ToString(FindValue.Findvalue((nL - keyLitera.PopFirst()) % Languege.z));
                if (keyLitera.Count == 0)
                    sequence(element.Key, keyLitera);

            }
            return element.Encoded;
        }

        void sequence(int[,] coefficients, LimitedSizeStack<int> key)
        {
            key.Restore();
            for (int i = 0; i < coefficients.GetLength(1); i++)
            {
                int newElementSequence = 0;
                for (var j = 0; j <= coefficients.GetLength(0); j++)
                {
                    var multiplier = key.PopLast();
                    newElementSequence += coefficients[0, j] * multiplier;
                }
                key.Restore();
                key.Push(newElementSequence);
            }
        }
    }
}
