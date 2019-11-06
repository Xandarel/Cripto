using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;

namespace CriptoClass
{
    public class Vishener
    {
        public string word { get; set; }
        public string key { get; set; }

        public string Code()
        {
            var numberLitera = Converter.ConvertWordToCode(word);
            var keyLitera = new int[word.Length];
            //Создает массив по ключу. Циклически записывает ключ в строку длинны кодируемого слова
            //TODO придумать как написать реализацию красивее и для общего случая
            for (int i = 0; i < keyLitera.Length; i++)
                keyLitera[i] = Languege.dictionary[key[i % key.Length]];
            string result = "";
            //Шифрование слова. 
            //Коды слов последовательно суммируются и высчитывается новое значение буквы в кольце выбранного алфавита
            for (int i = 0; i < numberLitera.Length; i++)
                result += Convert.ToString(FindValue((numberLitera[i] + keyLitera[i]) % Languege.z));
            return result;
        }

        public static string Decode(Vishener element)
        {
            var numberLitera = Converter.ConvertWordToCode(element.word);
            var keyLitera = new int[element.word.Length];
            for (int i = 0; i < keyLitera.Length; i++)
                keyLitera[i] = Languege.dictionary[element.key[i % element.key.Length]];
            string result = "";
            for (int i = 0; i < numberLitera.Length; i++)
            {
                var dec = (numberLitera[i] - keyLitera[i]) % Languege.z;
                result += Convert.ToString(element.FindValue(dec));
            }
            return result;
        }
        char FindValue(int key)
        {
            var inversekey = Languege.z + key; // + потому, что ключ точно меньше длинны кольца.
            if (key > 0)
            {
                foreach (var pair in Languege.dictionary)
                    if (pair.Value == key)
                        return pair.Key;
            }
            else
            {
                foreach (var pair in Languege.dictionary)
                    if (pair.Value == inversekey)
                        return pair.Key;
            }
            return ' '; //теперь точно никогда сюда код не придет
        }
    }
}
