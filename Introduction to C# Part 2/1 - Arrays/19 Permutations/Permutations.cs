using System;
using System.Collections.Generic;

class Permutations
{
    public static void recurse(int[] a, int currentPos, int totalLoops, int start, int[] taken)
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

        for (int i = start; i <= totalLoops; i++)
        {
            if (taken[i-1] != 1)
            {
                taken[i-1] = 1;
                a[currentPos] = i;
                recurse(a, currentPos + 1, totalLoops, start, taken);
                taken[i - 1] = 0;
            }
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Please enter N: ");
        int N = int.Parse(Console.ReadLine());
        int[] numbers = new int[N];
        int[] taken = new int[N];
        recurse(numbers, 0, N, 1, taken);
    }
}