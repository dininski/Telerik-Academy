using System;

class SuperSum
{
    static int[,] sums;

    public static int SSum(int K, int N)
    {
        if (K == 0)
        {
            return N;
        }
        else if (N == 1)
        {
            return 1;
        }
        else
        {
            sums[K, N] = SSum(K - 1, N) + SSum(K, N - 1);
            return sums[K, N];
        }
    }

    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int K = int.Parse(input[0]);
        int N = int.Parse(input[1]);
        sums = new int[K + 1, N + 1];
        Console.WriteLine(SSum(K, N));
    }
}
