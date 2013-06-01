// Write a program that reads from the console a sequence of
// positive integer numbers. The sequence ends when empty line
// is entered. Calculate and print the sum and average of the
// elements of the sequence. Keep the sequence in List<int>.

namespace SumAndAverage
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbersEntered = new List<int>();
            Console.WriteLine("Enter some numbers separated by a new line.");
            Console.WriteLine("Press enter to finish entering.");
            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int parsedNumber = int.Parse(input);
                numbersEntered.Add(parsedNumber);
                input = Console.ReadLine();
            }

            int sum = 0;
            for (int i = 0; i < numbersEntered.Count; i++)
            {
                sum += numbersEntered[i];
            }

            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine("Average: {0}", (double)sum / numbersEntered.Count);
        }
    }
}