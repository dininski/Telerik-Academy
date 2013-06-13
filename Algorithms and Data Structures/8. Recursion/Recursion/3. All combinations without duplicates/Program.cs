/* Modify the previous program to skip duplicates:
n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
*/
namespace CombinationsNoDuplicates
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter number of elements:");
            int maxElements = int.Parse(Console.ReadLine());
            Console.Write("Please enter set size: ");
            int setSize = int.Parse(Console.ReadLine()); 
            Recursive(0, new int[setSize], 1, maxElements);
        }

        public static void Recursive(int index, int[] result, int start, int max)
        {
            if (index == result.Length)
            {
                Print(result);
            }
            else
            {
                for (int i = start; i <= max; i++)
                {
                    if ((index == 0) || (index > 0 && result[index - 1] < i))
                    {
                        result[index] = i;
                        Recursive(index + 1, result, start + 1, max);
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
