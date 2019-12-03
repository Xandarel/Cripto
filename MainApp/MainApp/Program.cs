using System;
using System.Collections.Generic;
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
            Languege.Libra("eng");
            var key = new List<Matrix<double>>();
            key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 3, 4 }, { 3, 7 } }));
            key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { {5}, {7} }));
            Console.WriteLine(key[0]);
            Console.WriteLine(key[1]);
            var libra = new WordAndKey<List<Matrix<double>>>("TOWN",key);
            var tr = new Hill();
            tr.Code(libra);
            Console.WriteLine(libra.Encoded);
        }
    }
}
