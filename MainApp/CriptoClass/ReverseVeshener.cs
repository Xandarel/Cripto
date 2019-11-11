using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;

namespace CriptoClass
{
    public class ReverseVeshener : Interfase_criptoelements<WordAndKey<string>>
    {
        WordAndKey<string> element;
        public ReverseVeshener(string text,string key)
        {
            element = new WordAndKey<string>(text, key);
        }
        public string Code()
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word); // перевод слова в код
            var keyLitera = Converter.ConvertWordToCode(element.Key);// перевод ключа в код
            var result = new int[element.Word.Length];
            int k = 0;
            for (var i = 0; i < numberLitera.Length / keyLitera.Length; i++)//TODO: работает неверно. доделать
            {
                int line = keyLitera.Length + k;
                for (int j = k; j < line; j++)
                {
                    if (i == 0)
                        result[j] = (numberLitera[j] + keyLitera[j]) % Languege.z;
                    else
                        result[j] = (numberLitera[j] + numberLitera[j - k]) % Languege.z;
                }
            }
            var stringResult = "";
            foreach (var el in result)
                stringResult += FindValue.Findvalue(el);
            return stringResult;


        }

        public string Decode()//TODO: реализовать
        {
            throw new NotImplementedException();
        }
    }
}
