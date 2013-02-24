using System;
using System.Text;

class MultiTaskSolver
{
    public static string ReverseDigits(string number)
    {
        StringBuilder result = new StringBuilder();
        if (number[0] == '-')
        {
            result.Append("-");
            for (int i = number.Length - 1; i > 0; i--)
            {
                result.Append(number[i]);
            }
        }
        else
        {
            for (int i = number.Length - 1; i >= 0; i--)
            {
                result.Append(number[i]);
            }
        }

        return result.ToString();
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

    public static void PrintMenu()
    {
        Console.WriteLine("Please select operation:");
        Console.WriteLine("1 to reverse digits of a number");
        Console.WriteLine("2 to calculate average of a sequence of numbers");
        Console.WriteLine("3 to solve a linear equation");
    }

    public static void CheckAndReverse()
    {
        string number = "-";
        while (number[0] == '-')
        {
            Console.Write("Please enter a non-negative number: ");
            number = Console.ReadLine();
        }
        Console.WriteLine(ReverseDigits(number)); 
    }

    public static void CheckAndAverage()
    {
        string sequenceOfNums = "";
        while (sequenceOfNums == "")
        {
            Console.WriteLine("Please enter a non-empty sequence of numbers, separated by a space: ");
            sequenceOfNums = Console.ReadLine();
        }
        string[] numberString = sequenceOfNums.Split(' ');
        int[] nums = new int[numberString.Length];
        for (int i = 0; i < numberString.Length; i++)
        {
            nums[i] = int.Parse((numberString[i]));
        }
        Console.WriteLine(Average(nums)); 
    }

    public static void CheckAndSolve()
    {
        string aInput = "0";
        Console.WriteLine("a*x + b = 0");
        while (aInput == "0")
        {
            Console.WriteLine("Please enter a (a must not be equal to 0):");
            aInput = Console.ReadLine();
        }
        float a = float.Parse(aInput);
        Console.WriteLine("Please enter b:");
        float b = float.Parse(Console.ReadLine());
        float x = b / a;
        Console.WriteLine("x = {0}", x);
    }

    public static void DoOperation(int selection)
    {
        if (selection == 1)
        {
            CheckAndReverse();
        }
        else if (selection == 2)
        {
            CheckAndAverage();
        }
        else if (selection == 3)
        {
            CheckAndSolve();
        }
    }

    static void Main(string[] args)
    {
        PrintMenu();
        int selection = int.Parse(Console.ReadLine());
        DoOperation(selection);
    }
}