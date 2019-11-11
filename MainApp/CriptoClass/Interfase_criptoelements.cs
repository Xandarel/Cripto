using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoClass
{
    interface Interfase_criptoelements<T> //TODO: посмотреть как аботают интерфейсы. Написать правильно
    {
        string Code();
        string Decode();
    }
}
