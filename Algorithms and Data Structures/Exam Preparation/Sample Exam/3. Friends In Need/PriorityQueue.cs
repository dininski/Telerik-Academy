using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;
namespace FriendsInNeed
{
    public class PriorityQueue
    {
        OrderedBag<Node> elements;

        public PriorityQueue()
        {
            this.elements = new OrderedBag<Node>();
        }

        public void Enqueue(Node newNode)
        {
            this.elements.Add(newNode);
        }

        public Node Dequeue()
        {
            var nodeToDelete = this.elements.GetFirst();
            this.elements.Remove(nodeToDelete);
            return nodeToDelete;
        }

        public Node Peek()
        {
            return this.elements.GetFirst();
        }
    }

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

        public void Enqueue(T element)
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

        public T Dequeue()
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

        public T Peek()
        {
            return this.elements[0];
        }
    }
}
