// We are given the following sequence:
// S1 = N;
// S2 = S1 + 1;
// S3 = 2*S1 + 1;
// S4 = S1 + 2;
// S5 = S2 + 1;
// S6 = 2*S2 + 1;
// S7 = S2 + 2;
// ...
// Using the Queue<T> class write a program to print its
// first 50 members for given N.
// Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

namespace QueueSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number to go through the sequence:");

            int userInput = int.Parse(Console.ReadLine());

            Queue<int> sequenceQueue = new Queue<int>();
            sequenceQueue.Enqueue(userInput);

            int counter = 0;
            while (counter < 50)
            {
                int currentNumber = sequenceQueue.Dequeue();
                sequenceQueue.Enqueue(currentNumber + 1);
                sequenceQueue.Enqueue(2*currentNumber + 1);
                sequenceQueue.Enqueue(currentNumber + 2);
                Console.Write("{0} ", currentNumber);
                counter++;
            }
        }
    }
}
