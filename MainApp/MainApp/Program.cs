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
            Languege.Libra("rus");
            var key = new List<Matrix<double>>();
            key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 7,3}, { 1,4 } }));
            key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 2 }, { 7 } }));
            Console.WriteLine(key[0]);
            Console.WriteLine(key[1]);
            var libra = new WordAndKey<List<Matrix<double>>>("ЯМРИ", key);
            var tr = new Hill();
            tr.Decode(libra);
            Console.WriteLine(libra.Encoded);
        }
    }
}
