using System;

class PrintMatrix
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        byte n = byte.Parse(Console.ReadLine());
        for (int m = 0; m < n; m++)
        {
            int counter = m;
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                counter++;
                Console.Write("{0:00} ",counter);
            }
        }
        Console.WriteLine();
    }
}
