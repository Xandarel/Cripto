using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoClass
{
    interface Interfase_criptoelements //TODO: посмотреть как аботают интерфейсы. Написать правильно
    {
        public string Code();
        public static string Decode(<T> element);
    }
}
