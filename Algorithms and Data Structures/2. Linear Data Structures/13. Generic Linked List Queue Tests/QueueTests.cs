namespace LinkedListQueueTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GenericQueue;

    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void TestQueueEnqueueSingleElement()
        {
            Queue<int> testQueue = new Queue<int>();

            testQueue.Enqueue(1);

            Assert.AreEqual(1, testQueue.Size, "The size is not calculated correctly.");
        }

        [TestMethod]
        public void TestQueueEnqueueElements()
        {
            Queue<int> testQueue = new Queue<int>();

            int enqueueCount = 10;
            for (int i = 0; i < enqueueCount; i++)
            {
                testQueue.Enqueue(i);
            }

            Assert.AreEqual(enqueueCount, testQueue.Size, "The size is not calculated correctly.");
        }

        [TestMethod]
        public void TestQueueDequeueElements()
        {
            Queue<int> testQueue = new Queue<int>();

            int enqueueCount = 10;
            for (int i = 0; i < enqueueCount; i++)
            {
                testQueue.Enqueue(i);
            }

            for (int i = 0; i < enqueueCount; i++)
            {
                int currentElement = testQueue.Dequeue();
                Assert.AreEqual(i, currentElement, "The element are not being dequeued correctly.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestDequeueEmptyQueue()
        {
            Queue<int> testQueue = new Queue<int>();
            testQueue.Dequeue();
        }
    }
}
