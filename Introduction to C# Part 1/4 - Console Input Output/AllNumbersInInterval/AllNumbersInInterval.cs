using System;

namespace AllNumbersInInterval
{
    class AllNumbersInInterval
    {
        static void Main()
        {
            int interval;
            Console.WriteLine("Please enter a number:");
            int.TryParse(Console.ReadLine(), out interval);
            for (int i = 1; i <= interval; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
