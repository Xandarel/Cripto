using System;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Criptoclass;

namespace CriptoClass
{
     public static class InverseMatrix
    {
        public static Matrix<double> Inverse_Matrix(Matrix<double> matrix) //TODO: доделать. Понять как сделать союзную матрицу
        {
            var determinant = matrix.Determinant() % Languege.z; //Определитель матрицы в кольце
            for (var i=2;i<Languege.z;i++)
                if ((determinant*i)%Languege.z==0)
                {
                    determinant = (determinant * i) % Languege.z;// обратный элемент к определителю
                    break;
                }
            var bufArray = new double[matrix.ColumnCount, matrix.RowCount];
            for (var i = 0; i < matrix.ColumnCount; i++)
                for (var j = 0; j < matrix.RowCount; j++)
                    bufArray[i, j] =Math.Pow(-1,i+j) * GetMinor(matrix.ToArray(), j, i);
            var inverseMatrix = Matrix<double>.Build.DenseOfArray(bufArray).Transpose();
            inverseMatrix = (determinant * inverseMatrix)%Languege.z;
            return inverseMatrix;
        }

        static double GetMinor(double[,] arr, int row, int column)
        {
            double[,] buf = new double[arr.GetLength(0) - 1, arr.GetLength(0) - 1];
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) buf[i - 1, j] = arr[i, j];
                        if (i < row && j > column) buf[i, j - 1] = arr[i, j];
                        if (i > row && j > column) buf[i - 1, j - 1] = arr[i, j];
                        if (i < row && j < column) buf[i, j] = arr[i, j];
                    }
                }
            return Matrix<double>.Build.DenseOfArray(buf).Determinant()%Languege.z;
        }
    }
}
