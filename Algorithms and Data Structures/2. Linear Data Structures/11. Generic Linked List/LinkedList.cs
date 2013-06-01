// Implement the data structure linked list. Define a class
// ListItem<T> that has two fields: value (of type T) and
// NextItem (of type ListItem<T>). Define additionally a class
// LinkedList<T> with a single field FirstElement (of type
// ListItem<T>).

// I have added some additional methods such as Contains()
// as well as an indexer
namespace LinkedListImplementation
{
    using System;

    public class LinkedList<T> where T : IComparable
    {
        private ListItem head;
        private ListItem tail;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index > this.Count - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("The supplied index must be larger that 0 and less than the size of the list!");
                }

                ListItem currentNode = this.head;
                int counter = 0;

                while (counter != index)
                {
                    currentNode = currentNode.Next;
                    counter++;
                }

                return currentNode.Element;
            }

            set
            {
                if (index > this.Count - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("The supplied index must be larger that 0 and less than the size of the list!");
                }

                ListItem currentNode = this.head;
                int counter = 0;

                while (counter != index)
                {
                    currentNode = currentNode.Next;
                    counter++;
                }

                currentNode.Element = value;
            }
        }

        public void AddElement(T element)
        {
            if (this.head == null)
            {
                this.head = new ListItem(element);
                this.tail = this.head;
            }
            else
            {
                ListItem newNode = new ListItem(element, this.tail);
                this.tail = newNode;
            }

            this.Count++;
        }

        public T RemoveByIndex(int index)
        {
            int currentIndex = 0;
            ListItem currentNode = this.head;
            ListItem previousNode = null;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            this.Count--;

            if (this.Count == 0)
            {
                this.head = null;
            }
            else if (previousNode == null)
            {
                this.head = currentNode.Next;
            }
            else
            {
                previousNode.Next = currentNode.Next;
            }

            ListItem lastElement = null;

            if (this.head != null)
            {
                lastElement = this.head;
                while (lastElement.Next != null)
                {
                    lastElement = lastElement.Next;
                }
            }

            this.tail = lastElement;

            return currentNode.Element;
        }

        public int Remove(T obj)
        {
            ListItem currentNode = this.head;
            ListItem previousNode = null;
            int elementIndex = 0;

            while (currentNode != null)
            {
                if ((currentNode.Element.CompareTo(obj) == 0 && currentNode.Element != null)
                    || (currentNode.Element == null && obj == null))
                {
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
                elementIndex++;
            }

            if (currentNode != null)
            {
                this.RemoveByIndex(elementIndex);
                return elementIndex;
            }
            else
            {
                return -1;
            }
        }

        public int IndexOf(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("The element that you are searching for cannot be null!");
            }

            ListItem currentItem = this.head;
            int currentIndex = 0;

            if (!this.Contains(obj))
            {
                return -1;
            }

            while (currentItem.Element.CompareTo(obj) != 0 && currentItem != null)
            {
                currentItem = currentItem.Next;
                currentIndex++;
            }

            return currentIndex;
        }

        public bool Contains(T obj)
        {
            ListItem currentItem = this.head;

            while (currentItem != null)
            {
                if (currentItem.Element.CompareTo(obj) == 0)
                {
                    return true;
                }

                currentItem = currentItem.Next;
            }

            return false;
        }

        private class ListItem
        {
            public ListItem(T element)
            {
                this.Element = element;
                this.Next = null;
            }

            public ListItem(T element, ListItem previousNode)
            {
                this.Element = element;
                previousNode.Next = this;
            }

            public ListItem Next { get; set; }

            public T Element { get; set; }
        }
    }
}