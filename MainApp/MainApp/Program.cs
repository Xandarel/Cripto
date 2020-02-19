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
            FileStream fs = new FileStream("hillUpdateDatabase.txt", FileMode.OpenOrCreate);
            StreamWriter hillBase = new StreamWriter(fs, Encoding.Default);
            Random rnd = new Random();
            var key = new List<Matrix<double>>();
            while (true)
            {
                var text = Console.ReadLine();
                if (text == "end")
                    break;
                key = Generate.CreateKeys(text.Length);
                var libra = new WordAndKey<List<Matrix<double>>>(text, key);
                var tr = new Hill();
                var random = rnd.Next(0, Languege.z);
                tr.Code(libra,random);
                hillBase.WriteLine(libra.Word);
                hillBase.WriteLine(libra.Encoded);
                hillBase.WriteLine(random);
                hillBase.WriteLine(libra.Key[0].ToMatrixString());
                hillBase.WriteLine(libra.Key[1].ToMatrixString());
            }
            hillBase.Close();
            //key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 7,2}, { 29,29 } }));
            //key.Add(Matrix<double>.Build.DenseOfArray(new double[,] { { 15 }, { 6 } }));
            //var libra = new WordAndKey<List<Matrix<double>>>("САНЕАЙ", key);
            //var tr = new Hill();
            //tr.Decode(libra);
            //Console.WriteLine(libra.Encoded);
        }
    }
}
