using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoClass
{
    public class TheLinearCongruentialMethod
    {
        List<int> Period { get; set; }
        public void CreatePeriod(int m,int startElement)
        {
            var c = FindMutuallyPrimeNumbers(m);
        }

        int FindMutuallyPrimeNumbers(int m)
        {
            var mutuallyPrimeNumbers =new List<int>();
            for (var start=1;start<m;start++)
                if (IsCoprime(m, start))
                    mutuallyPrimeNumbers.Add(start);
            var rnd = new Random();
            return mutuallyPrimeNumbers[rnd.Next(0, mutuallyPrimeNumbers.Count)];
        }
        static bool IsCoprime(int a, int b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }
    }
}
