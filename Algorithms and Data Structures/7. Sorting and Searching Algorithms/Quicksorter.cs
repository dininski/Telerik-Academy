namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int startPos, int endPos)
        {
            int pivotPos = (startPos + endPos) / 2;
            T pivotValue = collection[pivotPos];

            int left = startPos;
            int right = endPos;

            while (left <= right)
            {
                while (collection[left].CompareTo(pivotValue) < 0)
                {
                    left++;
                }

                while (collection[right].CompareTo(pivotValue) > 0)
                {
                    right--;
                }

                if (left <= right)
                {
                    this.Swap(collection, left, right);
                    left++;
                    right--;
                }
            }

            if (left < endPos)
            {
                QuickSort(collection, left, endPos);
            }

            if (right > startPos)
            {
                QuickSort(collection, startPos, right);
            }
        }

        private void Swap(IList<T> collection, int firstPos, int secondPos)
        {
            T tempHolder = collection[firstPos];
            collection[firstPos] = collection[secondPos];
            collection[secondPos] = tempHolder;
        }
    }
}
