using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoClass
{
    class WordAndKey<T>
    {
        string word;
        T key;
        public WordAndKey(string word,T key)
        {
            this.word = word;
            this.key = key;
        }
        public string Word
        {
            get => word;
        }
        public T Key
        {
            get => key;
        }
    }
}
