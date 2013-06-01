namespace ShortestSequenceOfOperations
{
    using System;
    using System.Collections.Generic;

    public class OperationSequenceFinder
    {
        private readonly int endNumber;
        private readonly int startNumber;
        private readonly Queue<Tuple<int, int>> numbersQueue;

        public OperationSequenceFinder(int startNumber, int endNumber)
        {
            this.startNumber = startNumber;
            this.endNumber = endNumber;
            this.numbersQueue = new Queue<Tuple<int, int>>();
            this.numbersQueue.Enqueue(new Tuple<int, int>(this.startNumber, 0));
        }

        public int StartSeach()
        {
            return this.FindShortestSequence();
        }

        private int FindShortestSequence()
        {
            var currentItem = this.numbersQueue.Peek();
            var currentNumber = currentItem.Item1;
            var currentOccurences = currentItem.Item2;

            while (currentNumber != this.endNumber)
            {
                this.numbersQueue.Enqueue(new Tuple<int, int>(currentNumber + 1, currentOccurences + 1));
                this.numbersQueue.Enqueue(new Tuple<int, int>(currentNumber + 2, currentOccurences + 1));
                this.numbersQueue.Enqueue(new Tuple<int, int>(currentNumber * 2, currentOccurences + 1));
                currentItem = this.numbersQueue.Dequeue();
                currentNumber = currentItem.Item1;
                currentOccurences = currentItem.Item2;
            }

            return currentOccurences;
        }
    }
}
