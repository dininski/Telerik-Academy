namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var current in this.items)
            {
                if (current.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int currentIndex = (this.items.Count - 1) / 2;

            if (this.items[0].Equals(item))
            {
                return true;
            }

            while (currentIndex != 0 && currentIndex < this.items.Count && !this.items[currentIndex].Equals(item))
            {
                if (this.items[currentIndex].CompareTo(item) > 0)
                {
                    currentIndex /= 2;
                }
                else if (this.items[currentIndex].CompareTo(item) < 0)
                {
                    currentIndex *= 2;
                }
                else
                {
                    return true;
                }
            }

            if (currentIndex >= this.items.Count)
            {
                return false;
            }

            if (this.items[currentIndex].Equals(item))
            {
                return true;
            }

            return false;
        }

        public void Shuffle()
        {
            var elementCount = this.items.Count;
            for (int i = 0; i < elementCount; i++)
            {
                int pos = i + RandomGenerator.Instance.Next(0, elementCount - i);
                this.Swap(i, pos);
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private void Swap(int first, int second)
        {
            T temp = this.items[first];
            this.items[first] = this.items[second];
            this.items[second] = temp;
        }
    }
}
