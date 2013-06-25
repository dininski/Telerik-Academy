// You are given a set of infinite number of coins (1, 2 and 5) and end value – N. Write an
// algorithm that gives the number of coins needed so that the sum of the coins equals N.
// Example: N = 33 => 6 coins x 5 + 1 coin x 2 + 1 coin x 1

namespace Coins
{
    using System;

    public class Program
    {
        // the coins must be sorted in descending order
        static readonly int[] coinValues = new int[] { 5, 2, 1 };
        static int[] coinCount;
        static int valueToFind;

        public static void Main()
        {
            Console.Write("Please enter a value: ");
            valueToFind = int.Parse(Console.ReadLine());

            coinCount = new int[coinValues.Length];

            Greedy(coinCount, 0, 0);
        }

        public static void Greedy(int[] coinCount, int currentPos, int currentSum)
        {
            for (int i = currentPos; i < coinCount.Length; i++)
            {
                coinCount[i] = (valueToFind - currentSum) / coinValues[i];
                currentSum += coinCount[i] * coinValues[i];
            }

            if (currentSum == valueToFind && valueToFind > 0)
            {
                PrintCounts(coinCount);
            }
            else
            {
                Console.WriteLine("Cannot have a sum of {0} with coins with values {1} using greedy algorithm", valueToFind, string.Join(", ", coinValues));
            }
        }

        public static void PrintCounts(int[] coinCount)
        {
            for (int i = 0; i < coinCount.Length; i++)
            {
                Console.WriteLine("{0} coints with value {1}", coinCount[i], coinValues[i]);
            }
        }
    }
}
