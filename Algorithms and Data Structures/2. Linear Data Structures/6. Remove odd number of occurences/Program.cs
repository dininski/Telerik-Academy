// Write a program that removes from given sequence all
// numbers that occur odd number of times. Example:
// {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}


namespace OddNumberOfOccurences
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int[] testNumbers = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            var oddOccurences = new List<int>();

            Array.Sort(testNumbers);

            int currentOccurences = 1;
            for (int i = 0; i < testNumbers.Length - 1; i++)
            {
                if (testNumbers[i] == testNumbers[i + 1])
                {
                    currentOccurences++;
                }
                else
                {
                    if (currentOccurences % 2 == 0)
                    {
                        for (int j = 0; j < currentOccurences; j++)
                        {
                            oddOccurences.Add(testNumbers[i]);                            
                        }
                    }

                    currentOccurences = 1;
                }
            }

            if (currentOccurences % 2 == 0)
            {
                for (int j = 0; j < currentOccurences; j++)
                {
                    oddOccurences.Add(testNumbers[testNumbers.Length-1]);
                }
            }

            foreach (var number in oddOccurences)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();
        }
    }
}
