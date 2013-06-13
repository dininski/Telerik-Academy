/* Write a recursive program that simulates the execution of n nested loops from 1 to n.
 * Examples:
                           1 1 1
                           1 1 2
                           1 1 3
         1 1               1 2 1
n=2  ->  1 2      n=3  ->  ...
         2 1               3 2 3
         2 2               3 3 1
                           3 3 2
                           3 3 3
*/

namespace NestedLoops
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter a number: ");
            int userInput = int.Parse(Console.ReadLine());
            Recursive(0, new int[userInput], userInput);
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
                    result[index] = i;
                    Recursive(index + 1, result, max);
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
