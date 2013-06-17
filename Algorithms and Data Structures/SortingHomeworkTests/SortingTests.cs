namespace SortingHomeworkTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class SortingTests
    {
        private ISorter<int> sorter;

        [TestMethod]
        public void TestSelectionSortRandomCollection()
        {
            int[] randomCollection = new int[] { 1, 7, 3, 5, 9, 23, 68, 99 };
            this.InitializeSorter(new SelectionSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(randomCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void TestSelectionSortSortedCollection()
        {
            int[] sortedCollection = new int[] { 1, 3, 5, 7, 9, 23, 68, 99 };
            this.InitializeSorter(new SelectionSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(sortedCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void TestSelectionSortReverseSortedCollection()
        {
            int[] reverseCollection = new int[] { 99, 68, 23, 9, 7, 5, 3, 1 };
            this.InitializeSorter(new SelectionSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(reverseCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void TestMergeSortRandomCollection()
        {
            int[] randomCollection = new int[] { 1, 7, 3, 5, 9, 23, 68, 99 };
            this.InitializeSorter(new MergeSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(randomCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void TestMergeSortSortedCollection()
        {
            int[] sortedCollection = new int[] { 1, 3, 5, 7, 9, 23, 68, 99 };
            this.InitializeSorter(new MergeSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(sortedCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void TestMergeSortReverseSortedCollection()
        {
            int[] reverseCollection = new int[] { 99, 68, 23, 9, 7, 5, 3, 1 };
            this.InitializeSorter(new MergeSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(reverseCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void TestQuickSortRandomCollection()
        {
            int[] randomCollection = new int[] { 1, 7, 3, 5, 9, 23, 68, 99 };
            this.InitializeSorter(new SelectionSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(randomCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void TestQuickSortSortedCollection()
        {
            int[] sortedCollection = new int[] { 1, 3, 5, 7, 9, 23, 68, 99 };
            this.InitializeSorter(new SelectionSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(sortedCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        [TestMethod]
        public void TestQuickSortReverseSortedCollection()
        {
            int[] reverseCollection = new int[] { 99, 68, 23, 9, 7, 5, 3, 1 };
            this.InitializeSorter(new SelectionSorter<int>());
            SortableCollection<int> collection = new SortableCollection<int>(reverseCollection);
            collection.Sort(sorter);
            var result = collection.Items;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i].CompareTo(result[i + 1]) < 0);
            }
        }

        private void InitializeSorter(ISorter<int> sorter)
        {
            this.sorter = sorter;
        }
    }
}
