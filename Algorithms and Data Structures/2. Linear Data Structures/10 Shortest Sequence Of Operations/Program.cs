// * We are given numbers N and M and the following operations:
// N = N+1
// N = N+2
// N = N*2
// Write a program that finds the shortest sequence of operations
// from the list above that starts from N and finishes in M.
// Hint: use a queue.
// Example: N = 5, M = 16
// Sequence: 5 -> 7 -> 8 -> 16

namespace ShortestSequenceOfOperations
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter the initial number: ");
            int startNumber = int.Parse(Console.ReadLine());

            Console.Write("Please enter the desired number, after the operations: ");
            int endNumber = int.Parse(Console.ReadLine());

            OperationSequenceFinder sequencer = new OperationSequenceFinder(startNumber, endNumber);
            int shortest = sequencer.StartSeach();
            Console.WriteLine(shortest);
        }
    }
}
