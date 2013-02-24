using System;

namespace ConsoleApplication8
{
    class NegativePositive
    {
        static void Main()
        {
            for (int i = 2; i <= 102; i++)
            {
                if (i % 2 == 0)
                {
                    System.Console.Write("{0}, ", i);
                }
                else
                {
                    System.Console.Write("-{0}, ", i);
                }
            }
            System.Console.WriteLine("...");
        }
    }
}
