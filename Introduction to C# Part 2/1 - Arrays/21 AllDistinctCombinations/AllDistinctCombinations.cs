using System;

class AllDistinctCombinations
{
    public static void recurse(int[] a, int currentPos, int totalLoops, int start)
    {
        if (currentPos == a.Length)
        {
            foreach (int number in a)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
            return;
        }

        for (int i = start; i < totalLoops + 1; i++)
        {
            a[currentPos] = i;
            recurse(a, currentPos + 1, totalLoops, i+1);
        }

    }

    static void Main(string[] args)
    {

        Console.Write("Please enter N: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Please enter K: ");
        int K = int.Parse(Console.ReadLine());
        int[] numbers = new int[K];
        recurse(numbers, 0, N, 1);
    }
}