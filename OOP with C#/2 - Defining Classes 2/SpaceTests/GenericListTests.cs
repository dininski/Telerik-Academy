using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

namespace SpaceTests
{
    [TestClass]
    public class GenericListTests
    {
        static GenericList<int> intList;

        [TestMethod]
        public void GenericListIntInit()
        {
            intList = new GenericList<int>(5);
        }


        [TestMethod]
        [ExpectedException (typeof(IndexOutOfRangeException))]
        public void GenericListNoElements()
        {
            intList.Get(0);
        }

        [TestMethod]
        public void GenericListAddElements()
        {
            intList.Add(5);
            intList.Add(6);
            intList.Add(7);
            intList.Add(8);
            intList.Add(9);
            intList.Add(10);
            Assert.IsTrue(intList.Size == 6);
            Assert.IsTrue("5,6,7,8,9,10,0,0,0,0".Equals(intList.ToString()));
        }

        [TestMethod]
        public void GenericListGetElements()
        {
            int[] expectedResults = { 5, 6, 7, 8, 9, 10 };
            
            for (int i = 0; i < intList.Size; i++)
            {
                Assert.AreEqual<int>(expectedResults[i], intList.Get(i));
            }
        }

        [TestMethod]
        public void GenericListRemoveElement()
        {
            int[] expectedResults = { 6, 8, 9 };

            //list is  { 5, 6, 7, 8, 9, 10 }
            intList.RemoveFromPos(0);
            //list now is { 6, 7, 8, 9, 10 }
            intList.RemoveFromPos(1);
            //list now is { 6, 8, 9, 10 }
            intList.RemoveFromPos(3);
            //list now should be { 6, 8, 9 }

            for (int i = 0; i < intList.Size; i++)
            {
                Assert.AreEqual<int>(expectedResults[i], intList.Get(i));
            }
        }

        [TestMethod]
        public void GenericListMinAndMaxElement()
        {
            Assert.IsTrue(intList.Min() == 6);
            Assert.IsTrue(intList.Max() == 9);
        }

        [TestMethod]
        public void GenericListInsertAtPosition()
        {
            intList.InsertAt(2,12);
            Assert.IsTrue(intList.Get(0)==6);
            Assert.IsTrue(intList.Get(1) == 8);
            Assert.IsTrue(intList.Get(2) == 12);
            Assert.IsTrue(intList.Get(3) == 9);
        }

        [TestMethod]
        public void GenericListFindByValue()
        {
            Assert.IsTrue(intList.Find(12) == 2);
            Assert.IsTrue(intList.Find(6) == 0);
            Assert.IsTrue(intList.Find(999) == -1);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GenericListGetElementFromInvalidPosition()
        {
            intList.Get(7);
        }

        [TestMethod]
        public void GenericListClearList()
        {
            intList.Clear();
            Assert.IsTrue(intList.Size == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GenericListRemoveFromEmptyList()
        {
            intList.RemoveFromPos(0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GenericListGetElementFromEmptyList()
        {
            intList.Get(0);
        }
    }
}
