namespace StackArrayTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StackImplementation;

    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestStackSizeNoElements()
        {
            Stack testStack = new Stack();
            Assert.AreEqual(0, testStack.Size(), "The size is not calculated correctly");
        }

        [TestMethod]
        public void TestStackAddElements()
        {
            Stack testStack = new Stack();
            testStack.Push(10);
            testStack.Push(10);
            testStack.Push(10);
            testStack.Push(10);
            Assert.AreEqual(4, testStack.Size(), "The size is not calculated correctly");
        }

        [TestMethod]
        public void TestStackResize()
        {
            Stack testStack = new Stack();
            int numberOfAddedElements = 12;

            for (int i = 0; i < numberOfAddedElements; i++)
            {
                testStack.Push(10);
            }

            Assert.AreEqual(numberOfAddedElements, testStack.Size(), "The size is not calculated correctly");
        }

        [TestMethod]
        public void TestStackValues()
        {
            Stack testStack = new Stack();
            int numberOfAddedElements = 12;

            for (int i = 0; i < numberOfAddedElements; i++)
            {
                testStack.Push(10 + i);
            }

            for (int i = 0; i < numberOfAddedElements; i++)
            {
                int currentElement = testStack.Pop();
                Assert.AreEqual(21 - i, currentElement, "The elements are not being popped correctly");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPopEmptyList()
        {
            Stack testStack = new Stack();
            testStack.Pop();
        }
    }
}