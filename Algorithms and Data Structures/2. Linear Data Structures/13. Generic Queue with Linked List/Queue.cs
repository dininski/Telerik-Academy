// Implement the ADT queue as dynamic linked list. Use
// generics (LinkedQueue<T>) to allow storing different
// data types in the queue.

namespace GenericQueue
{
    public class Queue<T>
    {
        private int size;
        private Node tail;
        private Node head;

        public Queue()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

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

            this.size++;
        }

        public T Dequeue()
        {
            T value = this.head.Value;
            if (this.head.Next != null)
            {
                this.head = this.head.Next;
            }

            this.size--;
            return value;
        }

        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node Next { get; set; }
        }
    }
}
