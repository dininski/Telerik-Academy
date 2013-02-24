using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.WriteLine("Please enter first number:");
        int first = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter seconds number:");
        int second = int.Parse(Console.ReadLine());
        while (first != 0 && second != 0)
        {
            if (first > second)
                first %= second;
            else
                second %= first;
        }

        if (first == 0)
            Console.WriteLine(second);
        else
            Console.WriteLine(first);
    }
}


