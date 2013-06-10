namespace PQtests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PQ;

    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        public void TestPriorityQueueCount()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Add(5);
            pq.Add(6);
            pq.Add(3);
            pq.Add(7);
            pq.Add(11);
            pq.Add(-5);
            pq.GetTop();
            pq.GetTop();
            Assert.AreEqual(4, pq.Count, "Incorrectly counting the queue elements");
        }

        [TestMethod]
        public void TestPriorityQueueOrder_1()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Add(5);
            pq.Add(6);
            pq.Add(3);
            pq.Add(7);
            pq.Add(11);
            pq.Add(-5);

            Assert.AreEqual(-5, pq.GetTop());
            Assert.AreEqual(3, pq.GetTop());
            Assert.AreEqual(5, pq.GetTop());
            Assert.AreEqual(6, pq.GetTop());
            Assert.AreEqual(7, pq.GetTop());
            Assert.AreEqual(11, pq.GetTop());
        }

        [TestMethod]
        public void TestPriorityQueueOrder_2()
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Add(5);
            pq.Add(6);
            pq.Add(3);
            pq.Add(7);
            Assert.AreEqual(3, pq.GetTop(), "Incorrect element returned!");
            pq.Add(11);
            pq.Add(-5);
            Assert.AreEqual(-5, pq.GetTop(), "Incorrect element returned!");
            pq.Add(6);
            Assert.AreEqual(5, pq.GetTop(), "Incorrect element returned!");
            Assert.AreEqual(6, pq.GetTop(), "Incorrect element returned!");
            Assert.AreEqual(6, pq.GetTop(), "Incorrect element returned!");
            Assert.AreEqual(7, pq.GetTop(), "Incorrect element returned!");
            Assert.AreEqual(11, pq.GetTop(), "Incorrect element returned!");
        }
    }
}
