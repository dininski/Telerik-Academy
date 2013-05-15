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
            Assert.AreEqual(expectedBoard, actualBoard, "The boards are not being gerenated correctly!");
        }

        [TestMethod]
        public void TestWalkInMatrix_2()
        {
            int[,] board = WalkInMatrix.WalkInMatrix.GenerateRotatingWalkMatrix(3);

        }
    }
}
