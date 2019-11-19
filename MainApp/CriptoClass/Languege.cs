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
    }//TODO: написать кодирование слов в других системах исчисления (2,3,8,16)
}
