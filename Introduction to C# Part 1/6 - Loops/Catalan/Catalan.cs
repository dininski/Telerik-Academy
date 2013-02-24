using System;
using System.Numerics;

class Catalan
{
    private static BigInteger Factorial(BigInteger a)
    {
        BigInteger result = 1;
        if (a == 0)
        {
            return 1;
        }
        for (int i = 1; i < a + 1; i++)
        {
            result *= i;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Enter a number:");
        int n = int.Parse(Console.ReadLine());
        BigInteger catalanNumber;
        catalanNumber = Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));
        Console.WriteLine("The n-th Catalan number (where n is {0}) is {1}", n, catalanNumber);
    }
}

