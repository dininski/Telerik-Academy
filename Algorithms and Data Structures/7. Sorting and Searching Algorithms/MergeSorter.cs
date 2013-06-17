namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection);
        }

        private void MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            var left = new List<T>();
            var right = new List<T>();
            var middle = collection.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int j = middle; j < collection.Count; j++)
            {
                right.Add(collection[j]);
            }

            MergeSort(left);
            MergeSort(right);
            var result = Merge(left, right);

            for (int i = 0; i < result.Count; i++)
            {
                collection[i] = result[i];
            }
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            List<T> result = new List<T>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        result.Add(left[0]);
                        left.Remove(left[0]);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.Remove(right[0]);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.Remove(left[0]);
                }
                else if (right.Count > 0)
                {
                    result.AddRange(right);
                    right.Clear();
                }
            }

            return result;
        }
    }
}
