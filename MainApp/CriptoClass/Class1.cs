using System;
using System.Collections.Generic;

namespace Criptoclass
{
    public static class Languege
    {
        public static Dictionary<char, int> dictionary = new Dictionary<char, int>();
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
                    break;
                case "eng":
                    for (int i = Convert.ToInt32('A'); i <= Convert.ToInt32('Z'); i++)
                    {
                        if (!dictionary.ContainsKey(Convert.ToChar(i)))
                            dictionary[Convert.ToChar(i)] = i - Convert.ToInt32('A');
                    }
                    break;
            }
        }
    }
    public class Vishener
    {
        public string word { get; set; }
        public string key { get; set; }

        public string Code()
        {
            var numberLitera = new int[word.Length];
            int number = 0;
            foreach (var litera in word) // Перевод слова в код
            {
                numberLitera[number] = Languege.dictionary[litera];
                number++;
            }
            var keyArray = new char[word.Length];
            for (int i = 0; i < keyArray.Length; i++)
            {
                keyArray[i] = key[i % key.Length];
                Console.Write(keyArray[i]);
            }

            return "";

        }

    }
}
