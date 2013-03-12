using System;
using System.Collections.Generic;

class Tribonacci
{
    static long CalculateIt(long[] calculated, int elementToFind, int current)
    {
        calculated[current] = (calculated[current - 1] + calculated[current - 2] + calculated[current - 3]);
        if (elementToFind == current)
        {
            return calculated[current];
        }
        else
        {
            return CalculateIt(calculated, elementToFind, current + 1);
        }
    }

    static void Main(string[] args)
    {
        long[] tribonacci; ;
        string[] input = Console.ReadLine().Split(' ');
        int searchedElement = int.Parse(input[3]);
        if (searchedElement < 3)
        {
            tribonacci = new long[3];
        }
        else
        {
            tribonacci = new long[searchedElement];
        }

        tribonacci[0] = long.Parse(input[0]);
        tribonacci[1] = long.Parse(input[1]);
        tribonacci[2] = long.Parse(input[2]);

        if (searchedElement <= 3)
        {
            Console.WriteLine(tribonacci[searchedElement-1]);
        }
        else
        {
            Console.WriteLine(CalculateIt(tribonacci, searchedElement - 1, 3));
        }
    }
}
