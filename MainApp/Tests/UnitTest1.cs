using NUnit.Framework;
using CryptographicSecurity;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var cs = new FindHillsKey();
            var ansver = new List<int>();
            ansver.Add(2);
            ansver.Add(3);
            ansver.Add(6);
            //Assert.AreEqual(ansver, cs.PossiblePeriod(5, 6));
        }
    }
}