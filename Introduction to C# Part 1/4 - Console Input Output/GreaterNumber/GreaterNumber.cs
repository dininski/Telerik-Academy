using System;

namespace GreaterNumber
{
    class GreaterNumber
    {
        static void Main()
        {
            int number1;
            int number2;
            int greater;
            Console.WriteLine("Please enter first number to compare:");
            int.TryParse(Console.ReadLine(), out number1);
            Console.WriteLine("Please enter second number to compare:");
            int.TryParse(Console.ReadLine(), out number2);
            greater = Math.Max(number1, number2);
            Console.WriteLine("Of {0} and {1}, {2} is the greater one",number1, number2, greater);
        }
    }
}
