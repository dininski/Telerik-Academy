using System;

namespace Exercise_4
{
    class IsThirdDigit7
    {
        static void Main()
        {
            int number;
            Console.WriteLine("Enter a number");
            number = int.Parse(Console.ReadLine());
            number /= 100;
            if (number % 10 == 7)
            {
                Console.WriteLine("The third digit is 7");
            }
            else
            {
                Console.WriteLine("The third digit is not 7");
            }
        }
    }
}