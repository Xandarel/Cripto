using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;

namespace CriptoClass
{
    /// <summary>
    /// Шифр Виженера
    /// </summary>
    public class Vishener : Interfase_criptoelements<string>
    {
        public string Code(WordAndKey<string> element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var keyLitera = new int[element.Word.Length];
            //Создает массив по ключу. Циклически записывает ключ в строку длинны кодируемого слова
            //TODO придумать как написать реализацию красивее и для общего случая
            for (int i = 0; i < keyLitera.Length; i++)
                keyLitera[i] = Languege.dictionary[element.Key[i % element.Key.Length]];
            string result = "";
            //Шифрование слова. 
            //Коды слов последовательно суммируются и высчитывается новое значение буквы в кольце выбранного алфавита
            for (int i = 0; i < numberLitera.Count; i++)
                result += Convert.ToString(FindValue.Findvalue((numberLitera[i] + keyLitera[i]) % Languege.z));
            return result;
        }
        public string Decode(WordAndKey<string> element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word);
            var keyLitera = new int[element.Word.Length];
            for (int i = 0; i < keyLitera.Length; i++)
                keyLitera[i] = Languege.dictionary[element.Key[i % element.Key.Length]];
            string result = "";
            for (int i = 0; i < numberLitera.Count; i++)
            {
                var dec = (numberLitera[i] - keyLitera[i]) % Languege.z;
                result += Convert.ToString(FindValue.Findvalue(dec));
            }
            return result;
        }
    }
}
