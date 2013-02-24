using System;


class BiggestOfThree
{
    static void Main()
    {
        Console.WriteLine("a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("b:");
        int b = int.Parse(Console.ReadLine()); ;
        Console.WriteLine("c:");
        int c = int.Parse(Console.ReadLine()); ;

        if (a > b)
        {
            if (c > a)
            {
                Console.WriteLine("c = {0} is the biggest", c);
            }
            else
            {
                Console.WriteLine("a = {0} is the biggest", a);
            }
        }
        else if (b > c)
        {
            if (a > b)
            {
                Console.WriteLine("a = {0} is the biggest", a);
            }
            else
            {
                Console.WriteLine("b = {0} is the biggest", b);
            }
        }
        else if (c > a)
        {
            if (b > c)
            {
                Console.WriteLine("b = {0} is the biggest", b);
            }
            else
            {
                Console.WriteLine("c = {0} is the biggest", c);
            }
        }
    }
}

