// 1. Write a program that counts in a given array of double 
// values the number of occurrences of each value. Use
// Dictionary<TKey,TValue>.
// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
// -2.5 -> 2 times
// 3 -> 4 times
// 4 -> 3 times

namespace Occurences
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            double[] values = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            PrintOccurences(values);
        }

        public static void PrintOccurences(double[] values)
        {
            Dictionary<double, int> occurences = new Dictionary<double, int>();

            for (int i = 0; i < values.Length; i++)
            {
                if (!occurences.ContainsKey(values[i]))
                {
                    occurences.Add(values[i], 0);
                }

                occurences[values[i]]++;
            }

            foreach (var occurence in occurences)
            {
                Console.WriteLine("{0} -> {1}", occurence.Key, occurence.Value);
            }
        }
    }
}