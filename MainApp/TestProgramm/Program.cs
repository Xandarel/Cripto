using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using CriptoClass;
using CryptographicSecurity;
using Criptoclass;
using WeCantSpell.Hunspell;

namespace TestProgramm
{
    class Program
    {
        static void Main(string[] args)
        {
            Languege.Libra("ru");
            var crt = new ChineseRemainderTheorem();
            var el3 = new TheLinearCongruentialMethod();
            var el11 = new TheLinearCongruentialMethod();
            el3.CreatePeriod(3, 1);
            el11.CreatePeriod(11, 4);
            crt.CreatePeriod(el3.Period, el11.Period);
            foreach (var e in el3.Period)
                Console.Write($"{e} ");
            Console.WriteLine();
            foreach (var e in el11.Period)
                Console.Write($"{e} ");
            Console.WriteLine();
            foreach (var e in crt.Period)
                Console.Write($"{e} ");
            Console.ReadKey();

            //var candidat = new List<string>();
            //candidat.Add("собакц");
            //candidat.Add("сингапцр");
            //var ans = Bodymethod(@"Russian.dic", @"Russian.aff", -1, candidat);
            //foreach (var a in ans)
            //    Console.WriteLine(a);
            //Console.ReadKey();
        }

        static List<string> Bodymethod(string dicMode, string affMode, int length, List<string> candidat)
        {
            List<string> Keys = new List<string>();
            var dictionary = WordList.CreateFromFiles(dicMode, affMode);
            if (length == -1)
                foreach (var c in candidat)
                {
                    var suggestions = dictionary.Suggest(c);
                    foreach (var s in suggestions)
                        Keys.Add(s);
                }
            else
            {
                foreach (var c in candidat)
                {
                    if (c.Length < length)
                        continue;
                    else if (c.Length > length)
                        break;
                    else
                    {
                        var suggestions = dictionary.Suggest(c);
                        foreach (var s in suggestions)
                            Keys.Add(s);
                    }
                }
            }
            return Keys;
        }
    }
}