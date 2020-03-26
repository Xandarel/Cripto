using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CriptoClass
{
    public class TheLinearCongruentialMethod
    {
        public List<int> Period { get; set; }
        public TheLinearCongruentialMethod()
        {
            Period = new List<int>();
        }
        public void CreatePeriod(int m,int startElement)
        {
            var c = FindMutuallyPrimeNumbers(m);
            var dividersM = FindDividers(m);
            var simpleDividers = new List<int>();
            foreach (var div in dividersM)
                if (FindDividers(div).Count == 2)
                    simpleDividers.Add(div);
            if (m % 4 == 0) simpleDividers.Add(4);
            int b = FindB(simpleDividers);
            int a = b + 1;
            Period.Add(startElement);
            var flag = true;
            do
            {
                flag = true;
                var xi = (a * Period.Last() + c) % m;
                if (Period.Contains(xi))
                    flag = false;
                else
                    Period.Add(xi);
            } while (flag);
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
        static List<int> FindDividers(int element)
        {
            var result = new List<int>();
            for (int start = 1; start <= element / 2; start++)
                if (element % start == 0)
                    result.Add(start);
            result.Add(element);
            return result;
        }
        static int FindB(List<int> dividers)
        {
            for (var bCandidat = dividers.Max(); ; bCandidat++)
            {
                bool trueCandidat = true;
                foreach (var div in dividers)
                    if (bCandidat % div != 0)
                        trueCandidat = false;
                if (trueCandidat)
                    return bCandidat;
            }
        }
    }
}
