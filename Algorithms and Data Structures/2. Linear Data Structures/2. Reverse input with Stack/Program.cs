// Write a program that reads N integers from the console
// and reverses them using a stack. Use the Stack<int> class.

namespace PrintInReverse
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbersStack = new Stack<int>();

            Console.WriteLine("Enter numbers, separated by a new line.");
            Console.WriteLine("Enter an empty line to finish entering and display result.");
            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int parsedNumber = int.Parse(input);
                numbersStack.Push(parsedNumber);
                input = Console.ReadLine();
            }

            Console.WriteLine("The numbers is reverse order:");
            while (numbersStack.Count != 0)
            {
                int number = numbersStack.Pop();
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }
    }
}
