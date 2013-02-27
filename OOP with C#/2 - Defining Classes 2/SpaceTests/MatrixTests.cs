using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

namespace SpaceTests
{
    [TestClass]
    public class MatrixTests
    {
        public Matrix<double> matrix1;
        public Matrix<double> matrix2;
        public Matrix<double> result;

        public void FillMatricesWithValues()
        {
            matrix1 = new Matrix<double>(4, 4);
            for (int i = 0; i < matrix1.Cols; i++)
            {
                for (int j = 0; j < matrix1.Rows; j++)
                {
                    matrix1[i, j] = i;
                }
            }
            matrix2 = new Matrix<double>(4, 4);
            for (int i = 0; i < matrix2.Cols; i++)
            {
                for (int j = 0; j < matrix2.Rows; j++)
                {
                    matrix2[i, j] = i + 2;
                }
            }
        }

        [TestMethod]
        public void MatrixSumOfMatrices()
        {
            FillMatricesWithValues();
            result = matrix1 + matrix2;
            for (int i = 0; i < result.Cols; i++)
            {
                for (int j = 0; j < result.Rows; j++)
                {
                    Assert.AreEqual<double>(2 * i + 2, result[i, j]);
                }
            }
        }

        [TestMethod]
        public void MatrixSubstractMatrices()
        {
            FillMatricesWithValues();
            result = matrix1 - matrix2;
            for (int i = 0; i < result.Cols; i++)
            {
                for (int j = 0; j < result.Rows; j++)
                {
                    Assert.AreEqual<double>(i - i - 2, result[i, i]);                    
                }
            }
        }

        [TestMethod]
        public void MatrixMultiplication()
        {
            FillMatricesWithValues();
            result = matrix1 * matrix2;
            for (int i = 0; i < result.Cols; i++)
            {
                Assert.AreEqual<double>(i*(i+2), result[i,i]);
            }
        }

        [TestMethod]
        public void MatrixHasZero()
        {
            FillMatricesWithValues();

            matrix1[3, 2] = 0;

            bool matrix1HasZero;
            bool matrix2HasZero;

            if (matrix1)
            {
                matrix1HasZero = false;
            }
            else
            {
                matrix1HasZero = true;
            }

            if (matrix2)
            {
                matrix2HasZero = false;
            }
            else
            {
                matrix2HasZero = true;
            }

            Assert.IsTrue(matrix1HasZero);
            Assert.IsFalse(matrix2HasZero);
        }
    }
}
