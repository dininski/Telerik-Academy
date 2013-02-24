using System;
using System.Numerics;

class FactorialOfFirst100Numbers
{
    public static void CalculateFactorial(ref BigInteger[] factorialArray, int current)
    {
        factorialArray[current] = factorialArray[current - 1] * (current + 1);
    }

    static void Main(string[] args)
    {
        BigInteger[] factorial = new BigInteger[100];
        factorial[0] = 1;
        for (int i = 1; i < 100; i++)
        {
            CalculateFactorial(ref factorial, i);
        }

        for (int i = 0; i < factorial.Length; i++)
        {
            Console.Write("Factorial of {0} is {1}", i + 1, factorial[i]);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}