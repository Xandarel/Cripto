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
        public static Matrix<double> InverseMatrix(Matrix<double> matrix) //TODO: доделать. Понять как сделать союзную матрицу
        {
            var determinant = matrix.Determinant() % Languege.z; //Определитель матрицы в кольце
            for (var i=2;i<Languege.z;i++)
                if ((determinant*i)%Languege.z==0)
                {
                    determinant = (determinant * i) % Languege.z;// обратный элемент к определителю
                    break;
                }

        }
    }
}
