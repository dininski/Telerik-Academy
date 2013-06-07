using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericHashedSet;

namespace HashedSetTests
{
    [TestClass]
    public class HashedSetUnitTests
    {
        [TestMethod]
        public void HashedSetUnionTest()
        {
            HashedSet<int> firstSet = new HashedSet<int>();
            int firstSetLength = 5;
            for (int i = 0; i < firstSetLength; i++)
            {
                firstSet.Add(i);
            }

            HashedSet<int> secondSet = new HashedSet<int>();
            int secondSetLength = 5;
            for (int i = 0; i < secondSetLength; i++)
            {
                secondSet.Add(i + firstSetLength);
            }

            Assert.AreEqual(firstSetLength, firstSet.Count, "Incorrect set count!");
            Assert.AreEqual(secondSetLength, secondSet.Count, "Incorrect set count!");

            firstSet.Union(secondSet);

            for (int i = 0; i < firstSetLength + secondSetLength; i++)
            {
                Assert.IsTrue(firstSet.Contains(i), "Incorrect union!");
            }

            Assert.AreEqual(firstSetLength + secondSetLength, firstSet.Count, "Incorrect amount of elements after union");
        }

        [TestMethod]
        public void HashedSetUnionTestSameElementsInBoth()
        {
            HashedSet<int> firstSet = new HashedSet<int>();
            int firstSetLength = 5;
            for (int i = 0; i < firstSetLength; i++)
            {
                firstSet.Add(i);
            }

            HashedSet<int> secondSet = new HashedSet<int>();
            int secondSetLength = 5;
            for (int i = 0; i < secondSetLength; i++)
            {
                secondSet.Add(i);
            }

            Assert.AreEqual(firstSetLength, firstSet.Count, "Incorrect set count!");
            Assert.AreEqual(secondSetLength, secondSet.Count, "Incorrect set count!");

            firstSet.Union(secondSet);

            for (int i = 0; i < firstSetLength; i++)
            {
                Assert.IsTrue(firstSet.Contains(i), "Incorrect union!");
            }

            Assert.AreEqual(firstSetLength, firstSet.Count, "Incorrect amount of elements after union");
        }

        [TestMethod]
        public void HashedSetIntersectNoCommonElements()
        {
            HashedSet<int> firstSet = new HashedSet<int>();
            int firstSetLength = 5;
            for (int i = 0; i < firstSetLength; i++)
            {
                firstSet.Add(i);
            }

            HashedSet<int> secondSet = new HashedSet<int>();
            int secondSetLength = 5;
            for (int i = 0; i < secondSetLength; i++)
            {
                secondSet.Add(i + firstSetLength);
            }

            Assert.AreEqual(firstSetLength, firstSet.Count, "Incorrect set count!");
            Assert.AreEqual(secondSetLength, secondSet.Count, "Incorrect set count!");

            firstSet.Intersect(secondSet);

            Assert.AreEqual(0, firstSet.Count, "Incorrect amount of elements after union");
        }

        [TestMethod]
        public void HashedSetIntersect()
        {
            HashedSet<int> firstSet = new HashedSet<int>();
            int firstSetLength = 5;
            for (int i = 0; i < firstSetLength; i++)
            {
                firstSet.Add(i);
            }

            HashedSet<int> secondSet = new HashedSet<int>();
            int secondSetLength = 5;
            for (int i = 0; i < secondSetLength; i++)
            {
                secondSet.Add(i);
            }

            Assert.AreEqual(firstSetLength, firstSet.Count, "Incorrect set count!");
            Assert.AreEqual(secondSetLength, secondSet.Count, "Incorrect set count!");

            firstSet.Intersect(secondSet);

            for (int i = 0; i < firstSetLength; i++)
            {
                Assert.IsTrue(firstSet.Contains(i), "Incorrect intersect");
            }

            Assert.AreEqual(firstSetLength, firstSet.Count, "Incorrect amount of elements after union");
        }
    }
}
