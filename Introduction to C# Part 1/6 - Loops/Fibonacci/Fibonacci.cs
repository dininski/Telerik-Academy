using System;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        int limit = int.Parse(Console.ReadLine());
        BigInteger result = 0;
        BigInteger a = 0;
        BigInteger b = 1;

        
        for (int i = 0; i < limit+1; i++)
        {
            a = result + b;
            result = b;
            b = a;
        }
        result -= 1;

        Console.WriteLine("The sum of the first {0} Fibonacci numbers is {1}", limit, result);
    }
}
