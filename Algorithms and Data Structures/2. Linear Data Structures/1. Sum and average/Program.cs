using System;
using System.Collections.Generic;

namespace SumAndAverage
{
    class Program
    {
        static void Main(string[] args)
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