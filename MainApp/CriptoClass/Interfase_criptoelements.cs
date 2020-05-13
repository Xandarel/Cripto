using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoClass
{
    public interface Interfase_criptoelements<T>
    {
        string Code(WordAndKey <T> element);
        string Decode(WordAndKey<T> element);
    }
}
