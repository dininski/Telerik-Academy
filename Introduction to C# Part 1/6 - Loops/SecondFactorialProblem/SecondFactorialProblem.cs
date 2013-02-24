using System;
using System.Numerics;

namespace SecondFactorialProblem
{
    class SecondFactorialProblem
    {
        static void Main()
        {
            Console.WriteLine("Please enter the smaller integer:");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the bigger integer:");
            int K = int.Parse(Console.ReadLine());
            BigInteger result = 1;

            for (int i = 2; i <= N; i++)
            {
                result *= i;
            }

            for (int i = K - N + 1; i <= K; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
