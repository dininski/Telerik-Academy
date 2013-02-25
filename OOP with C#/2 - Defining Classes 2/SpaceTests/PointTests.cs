using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

namespace SpaceTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void Point3DZeroPointTest()
        {
            Point3D zeroPoint = Point3D.GetStartingPoint();
            Assert.IsTrue(zeroPoint.XPos == 0);
            Assert.IsTrue(zeroPoint.YPos == 0);
            Assert.IsTrue(zeroPoint.ZPos == 0);
        }

        [TestMethod]
        public void Point3DCreation()
        {
            Point3D somePoint = new Point3D();
            somePoint.XPos = 4;
            somePoint.YPos = 5;
            somePoint.ZPos = 6;
            Assert.IsTrue(somePoint.XPos == 4);
            Assert.IsTrue(somePoint.YPos == 5);
            Assert.IsTrue(somePoint.ZPos == 6);
        }
    }
}
