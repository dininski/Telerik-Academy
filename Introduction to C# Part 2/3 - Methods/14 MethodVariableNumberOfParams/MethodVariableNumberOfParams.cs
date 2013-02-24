using System;
using System.Numerics;


class VariableNumOfArgs
{
    public static int Minimum(params int[] intArray)
    {
        int currentSmallest = int.MaxValue;
        for (int i = 0; i < intArray.Length; i++)
        {
            if (intArray[i] < currentSmallest)
            {
                currentSmallest = intArray[i];
            }
        }
        return currentSmallest;
    }

    public static int Maximum(params int[] numbers)
    {
        int currentBiggest = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > currentBiggest)
            {
                currentBiggest = numbers[i];
            }
        }
        return currentBiggest;
    }

    public static int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    public static float Average(params int[] numbers)
    {
        return (float)Sum(numbers) / numbers.Length;
    }

    public static BigInteger Product(params int[] numbers)
    {
        BigInteger product = 1;
        foreach (var num in numbers)
        {
            product *= num;
        }
        return product;
    }

    static void Main()
    {
        Console.WriteLine("Using random number of parameters");
        Console.WriteLine("Minimum of 4, 5, 5, 1, 7, -3 is:");
        Console.WriteLine(Minimum(4, 5, 5, 1, 7, -3));
        Console.WriteLine("Maximum of 1, 6, 4, 4, 7, 78, 5, 43, 789 is:");
        Console.WriteLine(Maximum(1, 6, 4, 4, 7, 78, 5, 43, 789));
        Console.WriteLine("Sum of 2, 5, 7, 8, 5, 43, 12 is:");
        Console.WriteLine(Sum(2, 5, 7, 8, 5, 43, 12));
        Console.WriteLine("Average of 2, 5, 7, 8, 5, 43, 12 is:");
        Console.WriteLine(Average(2, 5, 7, 8, 5, 43, 12));
        Console.WriteLine("Product of 2, 3, 4, 5 is:");
        Console.WriteLine(Product(2, 3, 4, 5));
    }
}
