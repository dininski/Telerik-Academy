using System;

namespace NumberOfDividableBy5
{
    class NumberOfDividableBy5
    {
        static void Main()
        {
            int number1;
            int number2;
            int totalNumber = 0;
            Console.WriteLine("Please enter first number:");
            number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter second number:");
            number2 = int.Parse(Console.ReadLine());
            if (number1 > number2)
            {
                number1 = number2 + number1;
                number2 = number1 - number2;
                number1 = number1 - number2;
            }
            for (int i = number1; i <= number2; i++)
            {
                if (i % 5 == 0)
                {
                    totalNumber++;
                }
            }
            Console.WriteLine("Total number of numbers divisible by 5 between {0} and {1} is {2}",number1, number2, totalNumber);
        }
    }
}
