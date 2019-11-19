using System;
using Criptoclass;
using CriptoClass;
namespace MainApp
{
    class Program
    {
        static void Main()
        {
            Languege.Libra("ru");
            var libra = new WordAndKey<int[,]>("fool", new int[,] { 
                                                                    { 2, 1, 2 },
                                                                    { 0, 1, 2 }
            });
        }
    }
}
