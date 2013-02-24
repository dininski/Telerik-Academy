using System;

class CheckIfLeapYear
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a year and we will check if it is a leap year:");
        int year = int.Parse(Console.ReadLine());
        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("{0} is a leap year", year);
        }
        else
        {
            Console.WriteLine("{0} is not a leap year", year);
        }
    }
}