using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Criptoclass;
using CriptoClass;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace MainApp
{
    class Program
    {
        static void Main()
        {
            Languege.Libra("ru");
            #region
            FileStream fs = new FileStream("hillNewUpdateDatabase.txt", FileMode.OpenOrCreate);
            StreamWriter hillBase = new StreamWriter(fs, Encoding.Default);
            //Random rnd = new Random();
            #endregion
            #region
            var lcm3 = new TheLinearCongruentialMethod();
            var lcm11 = new TheLinearCongruentialMethod();
            var china = new ChineseRemainderTheorem();
            Random rnd = new Random();
            while (true)
            {
                var text = Console.ReadLine();
                if (text == "end")
                    break;
                var staticKey = Generate.CreateKeysMatrix(text.Length);
                var libra = new WordAndKey<List<Matrix<double>>>(text, staticKey);
                var tr = new Hill();
                lcm11.CreatePeriod(11, rnd.Next(0,11));
                lcm3.CreatePeriod(3, rnd.Next(0,3));
                china.CreatePeriod(lcm3.Period, lcm11.Period);
                tr.Code(libra,china.Period);
                hillBase.WriteLine(string.Join(" ", lcm3.Period));
                hillBase.WriteLine(string.Join(" ", lcm11.Period));
                hillBase.WriteLine(libra.Word);
                hillBase.WriteLine(libra.Encoded);
                foreach (var l in libra.Key)
                    hillBase.WriteLine(l.ToMatrixString());
            }
            hillBase.Close();
            #endregion //
            #region
            //key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 7, 2 }, { 29, 29 } }));
            //key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 15 }, { 6 } }));
            //var libra = new WordAndKey<List<Matrix<double>>>("БУБЛИКИ", key);
            //var tr = new Hill();
            //tr.Code(libra);
            //Console.WriteLine(libra.Encoded);
            #endregion
        }
    }
}
