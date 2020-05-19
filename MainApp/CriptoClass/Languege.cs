using System;
using System.Collections.Generic;

namespace Criptoclass
{
    public static class Languege
    {
        public static Dictionary<char, int> dictionary = new Dictionary<char, int>();
        public static List<int> setOfReversibleElements = new List<int>(); //множество обратимых элементов
        public static int z { get; set; } //размер кольца (сколько букв в алфавите)
        public static void Libra(string lang)
        {
            if (dictionary.Count > 0)
                dictionary.Clear();
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
                    SetReversibleElements(1, 2, 4, 5, 7, 8, 10, 12, 13, 14, 16, 17, 19, 20, 23, 25, 26, 28, 29, 31, 32);
                    z = 33;
                    break;
                case "eng":
                    for (int i = Convert.ToInt32('A'); i <= Convert.ToInt32('Z'); i++)
                    {
                        if (!dictionary.ContainsKey(Convert.ToChar(i)))
                            dictionary[Convert.ToChar(i)] = i - Convert.ToInt32('A');
                    }
                    SetReversibleElements(1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25);
                    z = 26;
                    break;
            }
        }
        static void SetReversibleElements(params int[] elements) => setOfReversibleElements.AddRange(elements);
    }
}
