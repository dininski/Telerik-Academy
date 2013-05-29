namespace GenericQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Queue<T>
    {
        public Queue()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        public void Enqueue(T element)
        {
            Node newElement = new Node(element);
            if (this.head == null)
            {
                this.head = newElement;
            }
            else
            {
                this.tail.Next = newElement;
                this.tail = newElement;
            }
        }

        private int size;
        private Node tail;
        private Node head;

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
