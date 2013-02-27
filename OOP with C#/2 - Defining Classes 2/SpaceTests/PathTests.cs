using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

namespace SpaceTests
{
    [TestClass]
    public class PathTests
    {
        public Path somePath = new Path();
        [TestMethod]
        public void PathTestSimpleTest()
        {
            Point3D a = new Point3D(1, 1, 1);
            Point3D b = new Point3D(2, 2, 2);
            somePath.AddPoint(a);
            somePath.AddPoint(b);
            Assert.IsTrue(somePath.GetPath()[0].Equals(a));
            Assert.IsTrue(somePath.GetPath()[1].Equals(b));
        }
    }
}
