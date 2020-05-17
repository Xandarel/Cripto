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
            var cip = new Permutation();
            var wk = new WordAndKey<int[,]>("скаслиуиа", new int[,] { 
                                                                    { 0, 1, 2 }, 
                                                                    { 1, 2, 0 } 
                                                                  });
            cip.Decode(wk);
            Console.WriteLine(wk.Encoded);
            Console.ReadKey();
        }
    }
}