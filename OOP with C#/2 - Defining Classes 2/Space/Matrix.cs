using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space
{
    public class Matrix<T> 
    {
        private readonly T[,] matrix;
        public Matrix(int row, int col)
        {
            matrix = new T[row,col];
        }

        public T this[int row,int col] 
        {
            get
            {
                return this.matrix[row,col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }

        public int GetRows()
        {
            return matrix.GetLength(0);
        }

        public int GetCols()
        {
            return matrix.GetLength(1);
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix) {
            if (firstMatrix.GetRows() > secondMatrix.GetRows() || (firstMatrix.GetCols() > secondMatrix.GetCols())) 
            {
                throw new ArgumentException("Matrices are of different size");
            }
            int rows = firstMatrix.GetRows();
            int cols = firstMatrix.GetCols();

            Matrix<T> resultMatrix = new Matrix<T>(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = (dynamic)firstMatrix[i,j] + secondMatrix[i,j];
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetRows() > secondMatrix.GetRows() || (firstMatrix.GetCols() > secondMatrix.GetCols()))
            {
                throw new ArgumentException("Matrices are of different size");
            }
            int rows = firstMatrix.GetRows();
            int cols = firstMatrix.GetCols();

            Matrix<T> resultMatrix = new Matrix<T>(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = (dynamic)firstMatrix[i, j] - secondMatrix[i, j];
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.GetRows() > secondMatrix.GetRows() || (firstMatrix.GetCols() > secondMatrix.GetCols()))
            {
                throw new ArgumentException("Matrices are of different size");
            }
            int rows = firstMatrix.GetRows();
            int cols = firstMatrix.GetCols();

            Matrix<T> resultMatrix = new Matrix<T>(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = (dynamic)firstMatrix[i, j] * secondMatrix[i, j];
                }
            }
            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.GetRows(); row++)
            {
                for (int col = 0; col < matrix.GetCols(); col++)
                {
                    if ((dynamic)matrix[row,col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
