using System;
using Criptoclass;
using CriptoClass;
namespace MainApp
{
    class Program
    {
        static void Main()
        {
            Languege.Libra("eng");
            var libra = new WordAndKey<int[,]>("FOOL", new int[,] { 
                                                                    { 2, 1, 2 },
                                                                    { 0, 1, 2 }
            });
            var tr = new CriptoClass.Transposition();
            tr.Code(libra);
        }
    }
}
