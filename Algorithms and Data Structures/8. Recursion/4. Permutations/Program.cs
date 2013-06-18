/* Write a recursive program for generating and printing all permutations of the numbers
 * 1, 2, ..., n for given integer number n. Example:
	n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3},	{2, 3, 1}, {3, 1, 2},{3, 2, 1}
*/

namespace Permutations
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter total number of elements: ");
            int setSize = int.Parse(Console.ReadLine());
            Recursive(0, new int[setSize], new bool[setSize], setSize);
        }

        public static void Recursive(int index, int[] result, bool[] used, int max)
        {
            if (index == result.Length)
            {
                Print(result);
            }
            else
            {
                for (int i = 1; i <= max; i++)
                {
                    if (!used[i - 1])
                    {
                        used[i - 1] = true;
                        result[index] = i;
                        Recursive(index + 1, result, used, max);
                        used[i - 1] = false;
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
