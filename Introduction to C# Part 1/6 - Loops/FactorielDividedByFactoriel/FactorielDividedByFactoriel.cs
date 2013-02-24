using System;
using System.Numerics;

namespace FactorielDividedByFactoriel
{
    class FactorielDividedByFactoriel
    {
        static void Main()
        {
            Console.WriteLine("Enter divisible:");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter divider:");
            int K = int.Parse(Console.ReadLine());
            BigInteger result = 1;

            for (int i = K + 1; i <= N; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);
        }
    }
}
