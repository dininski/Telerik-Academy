using System;
using System.Numerics;

class OddNumber
{
    static void Main()
    {
        int N;
        BigInteger[] numbers;
        BigInteger result;
        int.TryParse(Console.ReadLine(), out N);
        numbers = new BigInteger[N];
        for (int i = 0; i < N; i++)
        {
            BigInteger.TryParse(Console.ReadLine(), out numbers[i]);
        }

        result = numbers[0];

        for (int n = 1; n < N; n++)
        {
            result ^= numbers[n];
        }

        Console.WriteLine(result);
    }
}