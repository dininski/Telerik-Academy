// Implement the ADT stack as auto-resizable array. Resize
// the capacity on demand (when no space is available to 
// add / insert a new element).

namespace StackImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Stack
    {
        private const int DefaultStackSize = 10;
        private int currentElementPos = -1;
        private int[] stackArray;

        public Stack()
            : this(DefaultStackSize)
        {
        }

        public Stack(int initialSize)
        {
            this.stackArray = new int[initialSize];
        }

        public void Push(int elementToAdd)
        {
            if (this.currentElementPos == this.stackArray.Length - 1)
            {
                this.ResizeStackArray();
            }

            this.currentElementPos++;
            this.stackArray[this.currentElementPos] = elementToAdd;
        }

        public int Pop()
        {
            int elementToRemove = this.stackArray[this.currentElementPos];
            this.currentElementPos--;
            return elementToRemove;
        }

        public int Size()
        {
            return this.currentElementPos + 1;
        }

        private void ResizeStackArray()
        {
            int currentStackSize = this.stackArray.Length;
            int[] arrayCopyHolder = new int[currentStackSize];
            Array.Copy(this.stackArray, arrayCopyHolder, this.stackArray.Length);
            this.stackArray = new int[currentStackSize * 2];
            Array.Copy(arrayCopyHolder, this.stackArray, currentStackSize);
        }
    }
}
