using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoClass
{
    /// <summary>
    /// класс, в котором будет храниться слово, ключ, по которому это слово шифровалось и зашифрованное слово
    /// </summary>
    public class WordAndKey<T>
    {
        string word;
        T key;
        string encoded;
        public WordAndKey(string word,T key)
        {
            this.word = word;
            this.key = key;
            encoded = "";
        }
        public string Word { get => word; }
        public T Key { get => key; }
        public string Encoded { get => encoded; set => encoded += value; }
    }
}
