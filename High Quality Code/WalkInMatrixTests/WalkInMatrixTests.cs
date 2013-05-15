using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalkInMatrix;

namespace WalkInMatrixTests
{
    [TestClass]
    public class WalkInMatrixTests
    {
        [TestMethod]
        public void TestWalkInMatrix_1()
        {
            int[,] actualBoard = WalkInMatrix.WalkInMatrix.GenerateRotatingWalkMatrix(1);
            int[,] expectedBoard = { { 1 } };
            for (int i = 0; i < actualBoard.GetLength(0); i++)
            {
                for (int j = 0; j < actualBoard.GetLength(1); j++)
                {
                    Assert.AreEqual(expectedBoard[i, j], actualBoard[i, j], "The boards are not being gerenated correctly!");
                }
            }
        }

        [TestMethod]
        public void TestWalkInMatrix_2()
        {
            int[,] actualBoard = WalkInMatrix.WalkInMatrix.GenerateRotatingWalkMatrix(5);
            int[,] expectedBoard = {
                                   { 1, 13, 14, 15, 16 },
                                   { 12, 2, 21, 22, 17 },
                                   { 11, 23, 3, 20, 18 },
                                   { 10, 25, 24, 4, 19 },
                                   { 9, 8, 7, 6, 5 }
                                   };

            for (int i = 0; i < actualBoard.GetLength(0); i++)
            {
                for (int j = 0; j < actualBoard.GetLength(1); j++)
                {
                    Assert.AreEqual(expectedBoard[i, j], actualBoard[i, j], "The boards are not being gerenated correctly!");
                }
            }
        }
    }
}
