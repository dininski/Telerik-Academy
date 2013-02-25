using System;
using System.Text;

namespace Space
{
    public class GenericList<T>
        where T : IComparable
    {
        private T[] elements;
        private int currentPos = 0;
        private int arraySize;

        public GenericList(int size)
        {
            this.arraySize = size;
            elements = new T[arraySize];
        }

        public int Size
        {
            get
            {
                return currentPos;
            }
        }

        private void Resize()
        {
            arraySize *= 2;
            T[] temp = new T[arraySize];
            for (int i = 0; i < elements.Length; i++)
            {
                temp[i] = elements[i];
            }
            elements = temp;
        }

        public T Get(int pos)
        {
            if (pos >= Size)
            {
                throw new IndexOutOfRangeException();
            }
            return elements[pos];
        }

        public void Add(T elementToAdd)
        {
            if (currentPos == arraySize - 1)
            {
                Resize();
            }
            //once the array is resized (if necessary) - save element
            elements[currentPos++] = elementToAdd;
        }

        public int Find(T value)
        {
            for (int i = 0; i < currentPos; i++)
            {
                if (elements[i].Equals(value))
                {
                    return i;
                }
            }
            return -1;
        }

        public void RemoveFromPos(int index)
        {
            if (currentPos == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                currentPos--;
                for (int i = index; i < currentPos; i++)
                {
                    elements[i] = elements[i + 1];
                }
            }
        }

        public void InsertAt(int index, T value)
        {
            if (index >= arraySize)
            {
                Resize();
            }
            for (int i = currentPos+1; i > index; i--)
            {
                elements[i] = elements[i - 1];
            }
            elements[index] = value;
            currentPos++;
        }

        public void Clear()
        {
            currentPos = 0;
        }


        public T Min()
        {
            T smallestElement = elements[0] ;
            for (int i = 1; i < Size; i++)
            {
                if (smallestElement.CompareTo(elements[i]) > 0)
                {
                    smallestElement = elements[i];
                }
            }
            return smallestElement;
        }

        public T Max()
        {
            T largestElement = elements[0];
            for (int i = 1; i < Size; i++)
            {
                if (largestElement.CompareTo(elements[i]) < 0)
                {
                    largestElement = elements[i];
                }
            }
            return largestElement;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < arraySize; i++)
            {
                result.Append(elements[i]);
                if (i != arraySize - 1)
                {
                    result.Append(",");
                }
            }
            return result.ToString();
        }

    }
}
