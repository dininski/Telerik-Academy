using System;

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

        public int Rows
        {
            get
            {
            return matrix.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return matrix.GetLength(1);
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix) {
            if (firstMatrix.Rows > secondMatrix.Rows || (firstMatrix.Cols > secondMatrix.Cols)) 
            {
                throw new ArgumentException("Matrices are of different size");
            }
            int rows = firstMatrix.Rows;
            int cols = firstMatrix.Cols;

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
            if (firstMatrix.Rows > secondMatrix.Rows || (firstMatrix.Cols > secondMatrix.Cols))
            {
                throw new ArgumentException("Matrices are of different size");
            }
            int rows = firstMatrix.Rows;
            int cols = firstMatrix.Cols;

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
            if (firstMatrix.Rows > secondMatrix.Rows || (firstMatrix.Cols > secondMatrix.Cols))
            {
                throw new ArgumentException("Matrices are of different size");
            }
            int rows = firstMatrix.Rows;
            int cols = firstMatrix.Cols;

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
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
