using System;
using System.Collections.Generic;
using System.Text;
using Criptoclass;

namespace CriptoClass
{
    public static class FindValue
    {
        public static char Findvalue(int key)
        {
            var inversekey = Languege.z + key; // + потому, что ключ точно меньше длинны кольца.
            if (key >= 0)
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
