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
            key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 0, 3, 3 }, { 11, 1, 1 }, { 1, 4, 5 } }));
            key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 0 }, { 0 }, { 0 } }));
            Console.WriteLine(key[0]);
            Console.WriteLine(key[1]);
            var libra = new WordAndKey<List<Matrix<double>>>("CORRUPTIOOPTIMIPESSIMA",key);
            var tr = new Hill();
            tr.Decode(libra);
            Console.WriteLine(libra.Encoded);
        }
    }
}
