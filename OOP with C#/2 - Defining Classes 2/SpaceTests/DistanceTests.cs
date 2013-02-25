using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

namespace SpaceTests
{
    [TestClass]
    public class DistanceTest
    {
        double distance;
        [TestMethod]
        public void DistancePointsCoincide()
        {
            distance = Distance.DistanceBetweenPoints(new Point3D(1, 1, 1), new Point3D(1, 1, 1));
            Assert.IsTrue(distance == 0.0);
        }

        [TestMethod]
        public void DistancePointsInTheSamePlain()
        {
            distance = Distance.DistanceBetweenPoints(new Point3D(1,7,1), new Point3D(1,11,1));
            Assert.IsTrue(distance == 4.0);
        }

        [TestMethod]
        public void DistancePointsInCompletelyDifferentPlanes()
        {
            distance = Distance.DistanceBetweenPoints(new Point3D(1,2,3), new Point3D(10, 5, -1));
            Assert.IsTrue(distance == 10.295630140987);
        }
    }
}
