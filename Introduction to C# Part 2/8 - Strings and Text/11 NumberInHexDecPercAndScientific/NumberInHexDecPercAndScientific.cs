using System;

class NumberInHexDecPercAndScientific
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a number:");
        int userNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("The number in decimal: {0,15}", userNumber);
        Console.WriteLine("The number in decimal: {0,15:x}", userNumber);
        Console.WriteLine("The number in decimal: {0,15:p}", userNumber);
        Console.WriteLine("The number in decimal: {0,15:e}", userNumber);
    }
}
