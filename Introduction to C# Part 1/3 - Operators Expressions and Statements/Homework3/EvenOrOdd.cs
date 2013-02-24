using System;

namespace Homework3
{
    class EvenOrOdd
    {
        static void Main()
        {
            int checkMe;
            bool isEven;
            Console.WriteLine("Please enter a number:");
            checkMe = int.Parse(Console.ReadLine());
            isEven = checkMe % 2 == 0 ? true : false;

            Console.WriteLine(isEven);
        }
    }
}
