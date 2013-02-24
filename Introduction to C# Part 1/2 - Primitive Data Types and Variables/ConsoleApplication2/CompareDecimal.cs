using System;

namespace ConsoleApplication2
{
    class CompareDecimal
    {
        static void Main()
        {
            decimal firstNumber;
            decimal secondNumber;
            bool areEqual;
            while (true)
            {

                Console.Write("Please enter first number to compare:");
                firstNumber = decimal.Parse(Console.ReadLine());
                Console.Write("Please enter second number to compare:");
                secondNumber = decimal.Parse(Console.ReadLine());
                areEqual = (Math.Abs(firstNumber - secondNumber) < 0.000001m) ? true : false;
                Console.WriteLine(areEqual ? "They are equal, rounded to 0.000001" : "They are NOT equal, rounded to 0.000001");
            }
        }
    }
}
