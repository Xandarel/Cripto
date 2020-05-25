using NUnit.Framework;
using CryptographicSecurity;
using System.Collections.Generic;
using Criptoclass;
using CriptoClass;
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
        [Test]
        public void Transposition()
        {
            //Languege.Libra("ru");
            //var wk = new WordAndKey<int[,]>("абракадабра", new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            //var tranposition = new Transposition();
            //tranposition.Code(wk);
            //Assert.AreEqual(wk.Word, wk.Word);
            //Assert.AreEqual("0", wk.Encoded);
        }
        [Test]
        public void TestPermutation()
        {
            //Languege.Libra("ru");
            //var permut = new FindPermutationKey();
            //permut.FindKey("шифрывиженераа");
        }
    }
}