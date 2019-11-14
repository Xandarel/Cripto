using Criptoclass;

namespace CriptoClass
{
    public class ReverseVeshener : Interfase_criptoelements<string>
    {
        public string Code(WordAndKey<string> element)// Зарефакторить
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word); // перевод слова в код
            var keyLitera = Converter.ConvertWordToCode(element.Key);// перевод ключа в код
            var result = new int[element.Word.Length];
            int k = 0;
            int line = numberLitera.Length;
            for (int j = k; j < line; j++)
            {
                if (j < keyLitera.Length)//Первая итерация
                    result[j] = (numberLitera[j] + keyLitera[j]) % Languege.z;
                else //Последующие циклы
                {
                    result[j] = (numberLitera[j] + numberLitera[k]) % Languege.z;
                    k++;
                }
            }
            foreach (var el in result)
                element.Encoded = FindValue.Findvalue(el).ToString();
            return element.Encoded;
        }

        public string Decode(WordAndKey<string> element)//TODO: реализовать
        {
            var numberLitera = Converter.ConvertWordToCode(element.Word); // перевод слова в код
            var keyLitera = Converter.ConvertWordToCode(element.Key);// перевод ключа в код
            var result = new int[element.Word.Length];
            var k = 0;
            for (var i=0;i<numberLitera.Length;i++)
            {
                if (i < keyLitera.Length)//Первая итерация
                    result[i] = (numberLitera[i] - keyLitera[i]) % Languege.z;
                else //Последующие итерации
                {
                    result[i] = (numberLitera[i] - result[k]) % Languege.z;
                    k++;
                }
            }
            foreach (var el in result)
                element.Encoded = FindValue.Findvalue(el).ToString();
            return element.Encoded;
        }
    }
}
