// Write a program that finds in given array of integers
// (all belonging to the range [0..1000]) how many times 
// each of them occurs.
// Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
// 2 -> 2 times
// 3 -> 4 times
// 4 -> 3 times

namespace OccurencesCount
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] testArray = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            int[] occurences = new int[1001];

            for (int i = 0; i < testArray.Length; i++)
            {
                occurences[testArray[i]]++;
            }

            for (int i = 0; i < occurences.Length; i++)
            {
                if (occurences[i] != 0)
                {
                    Console.WriteLine("Number {0} occurs {1} times", i, occurences[i]);
                }
            }
        }
    }
}
