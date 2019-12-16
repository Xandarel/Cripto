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
            Languege.Libra("ru");
            var key = new List<Matrix<double>>();
            key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 7,2}, { 29,29 } }));
            key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 15 }, { 6 } }));
            Console.WriteLine(key[0]);
            Console.WriteLine(key[1]);
            var libra = new WordAndKey<List<Matrix<double>>>("САНЕАЙ", key);
            var tr = new Hill();
            tr.Decode(libra);
            Console.WriteLine(libra.Encoded);
        }
    }
}
