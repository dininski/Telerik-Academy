namespace GenericQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Queue<T>
    {
        private int size;
        private Node tail;
        private Node head;

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                this.size = value;
            }
        }


        public Queue()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public void Enqueue(T element)
        {
            Node newElement = new Node(element);

            // if the queue is empty, then the element that we add must be both
            // the head and the tail.
            if (this.head == null)
            {
                this.head = newElement;
                this.tail = newElement;
            }
            else
            {
                this.tail.Next = newElement;
                this.tail = newElement;
            }

            size++;
        }

        public T Dequeue()
        {
            T value = this.head.Value;
            if (this.head.Next != null)
            {
                this.head = this.head.Next;
            }

            size--;
            return value;
        }

        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }
    }
}
