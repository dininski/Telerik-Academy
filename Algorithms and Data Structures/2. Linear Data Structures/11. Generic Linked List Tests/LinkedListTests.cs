using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListImplementation;

namespace LinkedListUnitTests
{
    [TestClass]
    public class LinkedListTests
    {
        #region LinkedList indexer tests
        [TestMethod]
        [TestCategory("LinkedList indexers")]
        public void TestLinkedListGetIndexer_1()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddElement(1);
            list.AddElement(123);
            list.AddElement(999);
            list.AddElement(-1000);
            list.AddElement(0);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(123, list[1]);
            Assert.AreEqual(999, list[2]);
            Assert.AreEqual(-1000, list[3]);
            Assert.AreEqual(0, list[4]);
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod]
        [TestCategory("LinkedList indexers")]
        [ExpectedException(typeof(IndexOutOfRangeException), "Incorrectly comparing the size of the list with the list - index should be out of range!")]
        public void TestLinkedListGetIndexerInvalidIndex()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddElement(1);
            int shouldFail = list[1];
        }

        [TestMethod]
        [TestCategory("LinkedList indexers")]
        public void TestLinkedListSetIndexer_1()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddElement(1);
            list.AddElement(123);
            list.AddElement(999);
            list.AddElement(-1000);
            list.AddElement(0);

            list[0] = -1;
            list[1] = -123;
            list[2] = -999;
            list[3] = 1000;

            Assert.AreEqual(-1, list[0]);
            Assert.AreEqual(-123, list[1]);
            Assert.AreEqual(-999, list[2]);
            Assert.AreEqual(1000, list[3]);
            Assert.AreEqual(0, list[4]);
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod]
        [TestCategory("LinkedList indexers")]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestLinkedListSetIndexerInvalidIndex()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddElement(1);
            list[4] = 1;
        }

        #endregion

        #region LinkedList.IndexOf tests
        [TestMethod]
        [TestCategory("LinkedList.IndexOf()")]
        public void TestIndexOfValidElement()
        {
            int number = 10;
            LinkedList<int> list = new LinkedList<int>();
            list.AddElement(1);
            list.AddElement(10);
            list.AddElement(100);

            Assert.AreEqual(1, list.IndexOf(number));
        }

        [TestMethod]
        [TestCategory("LinkedList.IndexOf()")]
        public void TestIndexOfInvalidElement()
        {
            int number = 12;
            LinkedList<int> list = new LinkedList<int>();
            list.AddElement(1);
            list.AddElement(10);
            list.AddElement(100);
            Assert.AreEqual(-1, list.IndexOf(number));
        }

        [TestMethod]
        [TestCategory("LinkedList.IndexOf()")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestIndexOfNullElement()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.AddElement("sample string");
            list.IndexOf(null);
        }

        #endregion

    }
}
