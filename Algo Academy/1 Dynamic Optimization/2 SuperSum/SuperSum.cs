using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SuperSum
{
    static int[,] sums;
    public static int SSum(int K, int N)
    {
        if (K == 0)
        {
            sums[K, N] = N;
            return N;
        }
        else
        {
            for (int i = 1; i < N + 1; i++)
            {
                sums[K, N] += sums[K-1, i];
            }
        }
    }

    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int K = int.Parse(input[0]);
        int N = int.Parse(input[1]);
        sums = new int[K, N];
        Console.WriteLine(SSum(K,N));
    }
}
