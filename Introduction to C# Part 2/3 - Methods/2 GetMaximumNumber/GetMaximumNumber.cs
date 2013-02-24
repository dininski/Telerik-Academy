using System;

class GetMaximumNumber
{
    static int GetMax(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter 3 numbers:");
        Console.WriteLine("First number:");
        int first = int.Parse(Console.ReadLine());
        Console.WriteLine("Second number:");
        int second = int.Parse(Console.ReadLine());
        Console.WriteLine("Third number:");
        int third = int.Parse(Console.ReadLine());

        int max = GetMax(first, second);

        max = GetMax(max, third);

        Console.WriteLine("The largest number is: {0}", max);
    }
}
