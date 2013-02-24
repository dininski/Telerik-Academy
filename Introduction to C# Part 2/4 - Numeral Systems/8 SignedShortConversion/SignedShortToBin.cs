using System;
using System.Numerics;

class ShortToBin
{
    public static BigInteger ConvertShortToBin(short number)
    {
        BigInteger result = 0;
        BigInteger power = 1;
        if (number < 0)
        {
            result = 1111111111111111;
            number += 1;
        }

        while (number != 0)
        {
            result += (number % 2) * power;
            number /= 2;
            power *= 10;
        }
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a number to convert to binary:");
        short numberInDecimal = short.Parse(Console.ReadLine());
        Console.WriteLine(ConvertShortToBin(numberInDecimal));
    }
}