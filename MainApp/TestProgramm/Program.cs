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
            FindHillsKey hillsKey = new FindHillsKey();
            hillsKey.FindKey("сорока", "фэьъяо");
            var key = hillsKey.Ansver;
            foreach (var k in key)
                Console.WriteLine(k);
            Console.ReadKey();
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
        }
    }
}
