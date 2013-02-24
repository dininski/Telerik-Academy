using System;


class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter N:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter X:");
        int x = int.Parse(Console.ReadLine());
        int factorial = 0;
        int power = 1;
        double result = 1;

        for (int i = 0; i < n+1; i++)
        {
            factorial += i;
            result +=(double) factorial / power;
            power *= x;
        }

        Console.WriteLine("The result is: {0}", result);
    }
}

