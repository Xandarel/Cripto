using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using Criptoclass;
using System.Text;

namespace MainApp
{
    public class Generate
    {
        public static List<Matrix<double>> CreateKeys(int length)
        {
            Random rnd = new Random();
            var key = new List<Matrix<double>>();
            var first = new double[length, length];
            var second = new double[length, 1];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    first[i, j] = rnd.Next(0, Languege.z-1);
            for (int i = 0; i < length; i++)
                second[i,0]= rnd.Next(0, Languege.z - 1);
            key.Add(Matrix<double>.Build.DenseOfArray(first));
            key.Add(Matrix<double>.Build.DenseOfArray(second));
            return key;
        }
    }
}
