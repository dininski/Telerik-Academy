using System;
using System.Numerics;

class TrailingZeros
{
    static void Main()
    {
        Console.WriteLine("Please enter number:");
        int userInput = int.Parse(Console.ReadLine());
        BigInteger result = 1;
        int zeros = 0;
        for (int i = 1; i < userInput; i++)
        {
            result *= i;
            if (i % 5 == 0)
            {
                zeros++;
            }
        }
        Console.WriteLine("Factorial of {0} is {1} and has {2} trailing zero(s)", userInput, result, zeros);
    }
}

