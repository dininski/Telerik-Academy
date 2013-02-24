using System;

class TenRandomValues
{
    static void Main(string[] args)
    {
        Random generator = new Random();
        Console.WriteLine("Generating random numbers:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("{0} ", generator.Next(100, 201));
        }
        Console.WriteLine();
    }
}