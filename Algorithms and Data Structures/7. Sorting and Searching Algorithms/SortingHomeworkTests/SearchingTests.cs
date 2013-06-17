namespace SortingHomeworkTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class SearchingTests
    {
        [TestMethod]
        public void TestLinearSearchResultIsFirst()
        {
            int[] input = { -1, 5, 8, 3, 4, 67, 9, 3, 9, 4 };
            SortableCollection<int> sortableCol = new SortableCollection<int>(input);
            sortableCol.Sort(new MergeSorter<int>());
            bool containsItem = sortableCol.LinearSearch(-1);
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void TestLinearSearchResultIsLast()
        {
            int[] input = {8, 5, 8, 3, 4, 67, 9, 3, 9, -4 };
            SortableCollection<int> sortableCol = new SortableCollection<int>(input);
            sortableCol.Sort(new MergeSorter<int>());
            bool containsItem = sortableCol.LinearSearch(-4);
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void TestLinearSearchResultIsRandom()
        {
            int[] input = { -1, 5, 8, 3, 4, 67, -9, 3, 9, 4 };
            SortableCollection<int> sortableCol = new SortableCollection<int>(input);
            sortableCol.Sort(new MergeSorter<int>());
            bool containsItem = sortableCol.LinearSearch(-9);
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void TestLinearSearchResultIsNotContained()
        {
            int[] input = { -1, 5, 8, 3, 4, 67, -9, 3, 9, 4 };
            SortableCollection<int> sortableCol = new SortableCollection<int>(input);
            sortableCol.Sort(new MergeSorter<int>());
            bool containsItem = sortableCol.LinearSearch(0);
            Assert.IsFalse(containsItem);
        }

        [TestMethod]
        public void TestBinarySearchResultIsFirst()
        {
            int[] input = { -1, 5, 8, 3, 4, 67, 9, 3, 9, 4 };
            SortableCollection<int> sortableCol = new SortableCollection<int>(input);
            sortableCol.Sort(new MergeSorter<int>());
            bool containsItem = sortableCol.BinarySearch(-1);
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void TestBinarySearchResultIsLast()
        {
            int[] input = { 8, 5, 8, 3, 4, 67, 9, 3, 9, -4 };
            SortableCollection<int> sortableCol = new SortableCollection<int>(input);
            sortableCol.Sort(new MergeSorter<int>());
            bool containsItem = sortableCol.BinarySearch(-4);
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void TestBinarySearchResultIsRandom()
        {
            int[] input = { -1, 5, 8, 3, 4, 67, -9, 3, 9, 4 };
            SortableCollection<int> sortableCol = new SortableCollection<int>(input);
            sortableCol.Sort(new MergeSorter<int>());
            bool containsItem = sortableCol.BinarySearch(-9);
            Assert.IsTrue(containsItem);
        }

        [TestMethod]
        public void TestBinarySearchResultIsNotContained()
        {
            int[] input = { -1, 5, 8, 3, 4, 67, -9, 3, 9, 4 };
            SortableCollection<int> sortableCol = new SortableCollection<int>(input);
            sortableCol.Sort(new MergeSorter<int>());
            bool containsItem = sortableCol.BinarySearch(0);
            Assert.IsFalse(containsItem);
        }
    }
}
