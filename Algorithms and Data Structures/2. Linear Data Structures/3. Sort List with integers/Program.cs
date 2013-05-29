// Write a program that reads a sequence of integers
// (List<int>) ending with an empty line and sorts them in
// an increasing order.

namespace SortList
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> enteredNumbers = new List<int>();

            Console.WriteLine("Enter numbers, separated by a new line.");
            Console.WriteLine("Enter an empty line to finish entering and display result.");
            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int parsedNumber = int.Parse(input);
                enteredNumbers.Add(parsedNumber);
                input = Console.ReadLine();
            }

            enteredNumbers.Sort();

            for (int i = 0; i < enteredNumbers.Count; i++)
            {
                Console.Write("{0} ", enteredNumbers[i]);
            }

            Console.WriteLine();
        }
    }
}