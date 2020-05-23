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
            var candidat = new List<string>();
            candidat.Add("собакц");
            candidat.Add("сингапцр");
            var ans = Bodymethod(@"Russian.dic", @"Russian.aff", -1, candidat);
            foreach (var a in ans)
                Console.WriteLine(a);
            Console.ReadKey();
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