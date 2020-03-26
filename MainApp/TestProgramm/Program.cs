using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CriptoClass;

namespace TestProgramm
{
    class Program
    {
        static void Main(string[] args)
        {
            var lcm = new TheLinearCongruentialMethod();
            lcm.CreatePeriod(3, 2);
            foreach (var l in lcm.Period)
                Console.Write($"{l} ");
            Console.ReadKey();
        }
    }
}
