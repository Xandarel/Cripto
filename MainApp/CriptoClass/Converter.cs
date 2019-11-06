using Criptoclass;
using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoClass
{
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
}
