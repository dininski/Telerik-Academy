namespace HashTableTests
{
    using System;
    using GenericHashTable;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HashTableUnitTests
    {
        [TestMethod]
        public void TestEmptyHashTableCount()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int actualCount = integerTable.Count;
            Assert.AreEqual(0, actualCount, "The table count is incorrect when table is empty!");
        }

        [TestMethod]
        public void TestHashTableCount()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int numberOfElements = 10;

            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i);
            }

            int actualCount = integerTable.Count;
            Assert.AreEqual(numberOfElements, actualCount, "The table count is incorrectly calculated!");
        }


        [TestMethod]
        public void TestHashTableResizing()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int numberOfElements = 25;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i * 2);
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(i * 2, integerTable[i], "Incorrectly resizing the array!");
            }

            int actualCount = integerTable.Count;
            Assert.AreEqual(numberOfElements, actualCount, "The table count is incorrectly calculated!");
        }

        [TestMethod]
        public void TestHashTableClear()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int numberOfElements = 10;

            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i);
            }

            integerTable.Clear();

            int actualCount = integerTable.Count;
            Assert.AreEqual(0, actualCount, "The table count is incorrect when table is cleared!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The element was not correctly removed!")]
        public void TestHashTableRemove()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int numberOfElements = 10;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i);
            }

            integerTable.Remove(3);

            int actualCount = integerTable.Count;
            Assert.AreEqual(numberOfElements - 1, actualCount, "The table count is incorrect when table is an element is removed!");
            var shouldFail = integerTable[3];
        }

        [TestMethod]
        public void TestHashTableIndexerGetValidKey()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int numberOfElements = 10;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i + 5);
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(integerTable[i], i + 5, "The indexer is returning an incorrect value!");
            }
        }

        [TestMethod]
        public void TestHashTableIndexerSetValue()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();

            int numberOfElements = 10;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i + 5);
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable[i] = i + 2;
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(i + 2, integerTable[i], "The set indexer is not working correctly");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "No exception thrown with invalid key!")]
        public void TestHashTableIndexedGetInvalidKey()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int numberOfElements = 10;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i + 5);
            }

            var shouldFail = integerTable[numberOfElements];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "The hashtable cannot contain duplicate values")]
        public void TestHashTableAddDuplicate()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int key = 1;
            int value = 2;
            integerTable.Add(key, value);
            integerTable.Add(key, value);
        }

        [TestMethod]
        public void TestHashTableGetKeys()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int numberOfElements = 10;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i + 10);
            }

            var keys = integerTable.Keys();

            for (int i = 0; i < keys.Length; i++)
            {
                Assert.AreEqual(i, keys[i], "Returning incorrect keys!");
            }
        }

        [TestMethod]
        public void TestHashTableFind()
        {
            HashTable<int, int> integerTable = new HashTable<int, int>();
            int numberOfElements = 10;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerTable.Add(i, i + 10);
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                Assert.AreEqual(i + 10, integerTable.Find(i), "Returning incorrect keys!");
            }
        }
    }
}
