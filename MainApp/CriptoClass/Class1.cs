using System;
using System.Collections.Generic;

namespace Criptoclass
{
    public static class Languege
    {
        public static Dictionary<char, int> dictionary = new Dictionary<char, int>();
        public static int z { get; set; } //размер кольца (сколько букв в алфавите)
        public static void Libra(string lang)
        {
            switch (lang)
            {
                case "ru":
                    for (int i = Convert.ToInt32('А'); i <= Convert.ToInt32('Я'); i++)
                    {
                        if (!dictionary.ContainsKey(Convert.ToChar(i)))
                        {
                            if (i == Convert.ToInt32('Ж'))
                                dictionary['Ё'] = 6;
                            if (i >= Convert.ToInt32('Ж'))
                                dictionary[Convert.ToChar(i)] = i - Convert.ToInt32('А') + 1;
                            else
                                dictionary[Convert.ToChar(i)] = i - Convert.ToInt32('А');
                        }
                    }
                    z = 33;
                    break;
                case "eng":
                    for (int i = Convert.ToInt32('A'); i <= Convert.ToInt32('Z'); i++)
                    {
                        if (!dictionary.ContainsKey(Convert.ToChar(i)))
                            dictionary[Convert.ToChar(i)] = i - Convert.ToInt32('A');
                    }
                    z = 26;
                    break;
            }
        }
    }
    public static class Converter
    {
        public static int[] ConvertWordToCode(string text)
        {
            var numberLitera = new int[text.Length];
            int number = 0;
            foreach (var litera in text) // Перевод слова в код
            {
                numberLitera[number] = Languege.dictionary[litera];
                number++;
            }
            return numberLitera;
        }
    }
    public class Vishener
    {
        public string word { get; set; }
        public string key { get; set; }

        public string Code()
        {
            var numberLitera =Converter.ConvertWordToCode(word);
            var keyLitera = new int[word.Length];
            //Создает массив по ключу. Циклически записывает ключ в строку длинны кодируемого слова
            //TODO придумать как написать реализацию красивее и для общего случая
            for (int i = 0; i < keyLitera.Length; i++)
                keyLitera[i] = Languege.dictionary[key[i % key.Length]];
            string result="";
            //Шифрование слова. 
            //Коды слов последовательно суммируются и высчитывается новое значение буквы в кольце выбранного алфавита
            for(int i=0;i<numberLitera.Length;i++)
                result +=Convert.ToString(FindValue((numberLitera[i] + keyLitera[i]) % Languege.z));
            return result;
        }

        public static string Decode(Vishener element)//TODO написать красиво. Не нравится, что для декодирование нужен экземпляр элемента класса виженера
        {
            var numberLitera = Converter.ConvertWordToCode(element.word);
            var keyLitera = new int[element.word.Length];
            for (int i = 0; i < keyLitera.Length; i++)
                keyLitera[i] = Languege.dictionary[element.key[i % element.key.Length]];
            string result="";
            for (int i = 0; i < numberLitera.Length; i++)
                result += Convert.ToString(element.FindValue((numberLitera[i] - keyLitera[i]) % Languege.z));
            return result;
        }
        char FindValue(int key)
        {
            foreach (var pair in Languege.dictionary)
                if (pair.Value == key)
                    return pair.Key;
            return ' ';//Это часть кода никогда не вернется. так как в foreach найдется такое значение
        }
    }
    public class ReverseVeshener : Vishener
    {

    }


}
