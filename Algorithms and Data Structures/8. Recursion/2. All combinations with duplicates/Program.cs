/* Write a recursive program for generating and printing all the combinations with duplicates of
 * k elements from n-element set. Example:
	n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
*/
namespace CombinationsDuplicates
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static HashSet<int> used;
        public static void Main(string[] args)
        {
            used = new HashSet<int>();
            Console.Write("Please enter number of elements:");
            int maxElements = int.Parse(Console.ReadLine());
            Console.Write("Please enter set size: ");
            int setSize = int.Parse(Console.ReadLine());
            Recursive(0, new int[setSize], maxElements);
        }

        public static void Recursive(int index, int[] result, int max)
        {
            if (index == result.Length)
            {
                Print(result);
            }
            else
            {
                for (int i = 1; i <= max; i++)
                {
                    if (!used.Contains(i))
                    {
                        used.Add(i);
                        result[index] = i;
                        Recursive(index + 1, result, max);
                        used.Remove(i); 
                    }
                }
            }
        }

        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }
    }
}
