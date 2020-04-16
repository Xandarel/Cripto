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

namespace TestProgramm
{
    class Program
    {
        static void Main(string[] args)
        {
            Languege.Libra("ru");
            var cip = new Vishener();
            var word = new WordAndKey<string>("ШифрыВиженераподобновсеммногоалфавитнымшифрамнесохраняютчастотусимволовОднакоЕваможетиспользоватьнекоторыеметодыдлятогочтобырасшифроватьперехваченныйзашифрованныйтекстКриптоанализвданномслучаесостоитиздвухчастейнаходятдлинуключаипотомнепосредственнонаходятключ", "собака");
            var vigenerKey = new VigenereKey();

            word.Encoded=cip.Code(word);
            vigenerKey.FindKey(word.Encoded);
            var result = vigenerKey.GetKey;
            foreach (var r in result)
            {
                Console.WriteLine(r);
                Console.WriteLine("\n");
            }
            Console.ReadKey();
            //vigenerKey.FindKey()
            #region
            //Languege.Libra("ru");
            //FindHillsKey hillsKey = new FindHillsKey();
            //hillsKey.FindKey("сорока", "фэьъяо");
            //var key = hillsKey.Ansver;
            //foreach (var k in key)
            //    Console.WriteLine(k);
            //Console.ReadKey();
            #endregion
            #region
            //var lcm3 = new TheLinearCongruentialMethod();
            //var lcm11 = new TheLinearCongruentialMethod();
            //var crt = new ChineseRemainderTheorem();

            //lcm11.CreatePeriod(11, 3);
            //lcm3.CreatePeriod(50, 2);
            //crt.CreatePeriod(lcm3.Period, lcm11.Period);

            //Console.WriteLine("z=50");
            //foreach (var l in lcm3.Period)
            //    Console.Write($"{l} ");
            //Console.WriteLine();
            //Console.WriteLine("z=11");
            //foreach (var l in lcm11.Period)
            //    Console.Write($"{l} ");
            //Console.WriteLine();
            //Console.WriteLine("z=33");
            //foreach (var l in crt.Period)
            //    Console.WriteLine($"{l}");
            //Console.ReadKey();
            #endregion
        }
    }
}
