using System;


class SortThreeValues
{
    static void Main()
    {
        Console.WriteLine("a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("b:");
        int b = int.Parse(Console.ReadLine()); ;
        Console.WriteLine("c:");
        int c = int.Parse(Console.ReadLine()); ;

        if (a < b) // a < b
        {
            if (c < a) // c < a < b
            {
                Console.WriteLine("c = {0} is the smallest", c);
                Console.WriteLine("a = {0} is the middle", a);
                Console.WriteLine("b = {0} is the biggest", b);
            }
            else if (c < b) // a < c < b
            {
                Console.WriteLine("a = {0} is the smallest", a);
                Console.WriteLine("c = {0} is the middle", c);
                Console.WriteLine("b = {0} is the biggest", b);
            }
            else // a < b < c
            {
                Console.WriteLine("a = {0} is the smallest", a);
                Console.WriteLine("b = {0} is the middle", b);
                Console.WriteLine("c = {0} is the biggest", c);
            }
        }
        else if (b < c) // b < a && b < c
        {
            if (a < c) // b < a < c
            {
                Console.WriteLine("b = {0} is the smallest", b);
                Console.WriteLine("a = {0} is the middle", a);
                Console.WriteLine("c = {0} is the biggest", c);
            }
            else // b < c < a
            {
                Console.WriteLine("b = {0} is the smallest", b);
                Console.WriteLine("c = {0} is the middle", c);
                Console.WriteLine("a = {0} is the biggest", a);
            }
        }
        else if (c < a) // b < a && c < a
        {
            if (c < b) // b < a < c
            {
                Console.WriteLine("c = {0} is the smallest", c);
                Console.WriteLine("b = {0} is the middle", b);
                Console.WriteLine("a = {0} is the biggest", a);
            }
        }
    }
}

