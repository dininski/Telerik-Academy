using System;

namespace Exercise_5
{
    class IsThirdBit1or0
    {
        static void Main()
        {
            int testBit;
            Console.WriteLine("Please enter a number");
            testBit = int.Parse(Console.ReadLine());
            Console.Write("The third bit of the number {0} ", testBit);
            Console.WriteLine((1 & (testBit>>3)) != 0 ? "is 1" : "is 0");
        }
        }

    }
