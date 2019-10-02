using System;
using Criptoclass;
namespace MainApp
{
    class Program
    {
        static void Main()
        {
            Languege.Libra("ru");
            //foreach (var d in Languege.dictionary)
            //    Console.WriteLine(d);
            //Console.WriteLine(Languege.dictionary['A']);
            var example = new Vishener();
            example.key = "МОЗГ";
            example.word = "ТЕЛИФОН";
            Console.WriteLine(example.Code());
        }
    }
}
