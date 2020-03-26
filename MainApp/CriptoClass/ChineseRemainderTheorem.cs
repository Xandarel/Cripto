using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoClass
{
    public class ChineseRemainderTheorem
    {
        public List<int> Period { get; set; }
        public ChineseRemainderTheorem() => Period = new List<int>();
        public void CreatePeriod(List<int> smallerRing, List<int> largeRing)
        {
            int length = (smallerRing.Count * largeRing.Count) / GCD(smallerRing.Count, largeRing.Count);
            for (int pos=0;pos<length;pos++)
            {
                Period.Add(FindElement(smallerRing[pos % smallerRing.Count],smallerRing.Count, 
                                       largeRing[pos % largeRing.Count],largeRing.Count));
            }
        }

        private int FindElement(int smallerRingElement, int sizeSmallerRing, int largeRingElement, int sizeLargerRing)
        {
            for (int coefficient=0; ;coefficient++)
            {
                var element = sizeLargerRing * coefficient + largeRingElement;
                if (element % sizeSmallerRing == smallerRingElement)
                    return element;
            }
        }

        static int GCD(int a, int b)
        {
            if (a == 0)
                return b;
            else
            {
                var min = Min(a, b);
                var max = Max(a, b);
                //вызываем метод с новыми аргументами
                return GCD(max % min, min);
            }
        }
        static int Min(int x, int y) => x < y ? x : y;
        static int Max(int x, int y) => x > y ? x : y;
    }
}
