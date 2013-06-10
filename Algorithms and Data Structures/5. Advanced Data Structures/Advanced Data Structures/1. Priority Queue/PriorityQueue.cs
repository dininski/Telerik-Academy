namespace PQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            elements = new List<T>();
            nextElementPosition = 0;
        }

        private readonly List<T> elements;

        private int nextElementPosition;

        public int Count
        {
            get
            {
                return this.nextElementPosition;
            }
        }

        public void Add(T element)
        {
            if (nextElementPosition < this.elements.Count)
            {
                this.elements[nextElementPosition] = element;
            }
            else
            {
                this.elements.Add(element);
            }

            this.nextElementPosition++;
            this.Float(this.Count - 1);
        }

        public T GetTop()
        {
            var result = elements[0];
            this.SwapElements(0, this.Count - 1);
            this.elements.RemoveAt(this.Count - 1);
            this.nextElementPosition--;
            this.Sink(0);
            return result;
        }

        private void Float(int element)
        {
            int currentElementPos = element;
            int parent = (currentElementPos - 1) / 2;
            while (currentElementPos > 0 &&
                this.elements[parent].CompareTo(this.elements[currentElementPos]) > 0)
            {
                this.SwapElements(parent, currentElementPos);
                currentElementPos = parent;
                parent = (currentElementPos - 1) / 2;
            }
        }

        private void Sink(int pos)
        {
            int elementPos = pos;

            while (2 * elementPos < this.Count - 1)
            {
                int childPos = 2 * elementPos + 1;

                if (childPos < this.Count - 1 && this.elements[childPos].CompareTo(this.elements[childPos + 1]) > 0)
                {
                    childPos++;
                }

                if (this.elements[elementPos].CompareTo(this.elements[childPos]) < 0)
                {
                    break;
                }

                SwapElements(elementPos, childPos);
                elementPos = childPos;
            }
        }

        private void SwapElements(int parent, int child)
        {
            T holder = elements[parent];
            elements[parent] = elements[child];
            elements[child] = holder;
        }
    }
}
