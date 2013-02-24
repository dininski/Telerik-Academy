using System;
using System.Numerics;


class VariableNumOfArgs
{
    public static T Minimum<T>(params T[] numbers)
    {
        dynamic currentSmallest = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < currentSmallest)
            {
                currentSmallest = numbers[i];
            }
        }
        return currentSmallest;
    }

    public static T Maximum<T>(params T[] numbers)
    {
        dynamic currentBiggest = numbers[0];
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > currentBiggest)
            {
                currentBiggest = numbers[i];
            }
        }
        return currentBiggest;
    }

    public static T Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;
        foreach (var num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    public static float Average<T>(params T[] numbers)
    {
        dynamic sum = Sum(numbers);
        return (float)(sum / numbers.Length);
    }

    public static T Product<T>(params T[] numbers)
    {
        dynamic product = 1;
        foreach (var num in numbers)
        {
            product *= num;
        }
        return product;
    }

    static void Main()
    {
        Console.WriteLine("Using random number of parameters");
        Console.WriteLine("Minimum of 4, 5, 5, 1, 7, -3.123 is:");
        Console.WriteLine(Minimum(4, 5, 5, 1, 7, -3.123));
        Console.WriteLine("Maximum of 1, 6, 4, 4, 7, 78, 5, 43, 789.515949 is:");
        Console.WriteLine(Maximum(1, 6, 4, 4, 7, 78, 5, 43, 789.515949));
        Console.WriteLine("Sum of 2, 5, 7, 8, 5, 43, 12 is:");
        Console.WriteLine(Sum(2, 5, 7, 8, 5, 43, 12));
        Console.WriteLine("Average of 2, 5, 7, 8, 5, 43, 12.888 is:");
        Console.WriteLine(Average(2, 5, 7, 8, 5, 43, 12.888));
        Console.WriteLine("Product of 2, 3, 4.3412, 5 is:");
        Console.WriteLine(Product(2, 3, 4.3412, 5));
    }
}
