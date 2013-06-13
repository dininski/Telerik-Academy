namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minPos = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minPos]) < 1)
                    {
                        minPos = j;
                    }
                }

                if (minPos != i)
                {
                    this.Swap(collection, minPos, i);
                }
            }
        }

        private void Swap(IList<T> collection, int firstPos, int secondPos)
        {
            T holder = collection[firstPos];
            collection[firstPos] = collection[secondPos];
            collection[secondPos] = holder;
        }
    }
}
