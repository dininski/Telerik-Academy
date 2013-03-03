using System;
using System.Linq;

//Write a program that prints from given array of integers all numbers that are 
//divisible by 7 and 3. Use the built-in extension methods and lambda expressions.
//Rewrite the same with LINQ.

class DivisibleBy7and3
{
    static void Main(string[] args)
    {
        int[] someNumbers = new int[] { 4, 5, 21, 54, 12, 7, 0, 11, 221, 117, 105, 156, 147 };

        var usingLambda = someNumbers.Where(x => x % 21 == 0);


        Console.WriteLine("Using Lambda:");

        foreach (var item in usingLambda)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        var usingLinq = from n in someNumbers
                        where n % 21 == 0
                        select n;

        Console.WriteLine("Using Linq: ");

        foreach (var item in usingLambda)
        {
            Console.WriteLine(item);
        }

    }
}