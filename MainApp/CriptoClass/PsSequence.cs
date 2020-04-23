using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;

namespace CriptoClass
{
    /// <summary>
    /// шифр на основе псевдослучайной последовательности
    /// </summary>
    public class PsSequence : Interfase_criptoelements<int[,]>
    {
        public string Code(WordAndKey<int[,]> element)//TODO: понять, как реализовать в других системах исчисления
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var keyLitera = new LimitedSizeStack<int>(element.Key.GetLength(1));
            for (var i=0;i< element.Key.GetLength(1); i++)
                    keyLitera.Push(element.Key[1, i]);
            foreach (var nL in numberLitera)
            {
                element.Encoded = Convert.ToString(FindValue.Findvalue((nL + keyLitera.PopFirst()) % Languege.z));
                if (keyLitera.Count == 0)
                    Generate.sequence(element.Key, keyLitera);

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
                    Generate.sequence(element.Key, keyLitera);
            }
            return element.Encoded;
        }
    }
}
