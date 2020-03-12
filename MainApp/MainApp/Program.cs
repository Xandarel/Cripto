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
            var basis = new int[,] { { 2, 2, 1, 2 }, { 3, 1, 4, 2 } };
            var sequence = Generate.PseudorandomSequence(basis);
            var key = Generate.ModifiedHillMatrix(sequence, 4);
            //Console.Write($"{key}");
            while (true)
            {
                var text = Console.ReadLine();
                if (text == "end")
                    break;
                var staticKey = Generate.CreateKeysMatrix(text.Length);
                var libra = new WordAndKey<List<Matrix<double>>>(text, staticKey);
                var tr = new Hill();
                tr.Code(libra,sequence);
                hillBase.WriteLine(libra.Word);
                hillBase.WriteLine(libra.Encoded);
                hillBase.WriteLine(libra.Key[0].ToMatrixString());
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
