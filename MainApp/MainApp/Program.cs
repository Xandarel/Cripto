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
            var kodeVishener = new Vishener();
            kodeVishener.word = example.Code();
            kodeVishener.key = example.key;
            Console.WriteLine(Vishener.Decode(kodeVishener));
            Console.WriteLine(example.Code());
        }
    }
}
