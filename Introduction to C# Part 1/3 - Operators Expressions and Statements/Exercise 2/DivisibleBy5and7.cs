using System;

namespace Exercise_2
{
    class DivisibleBy5and7
    {
        static void Main()
        {
            int checkMe;
            Console.WriteLine("Please enter a number");
            checkMe = int.Parse(Console.ReadLine());
            Console.WriteLine(((checkMe % 5 == 0) && (checkMe % 7 == 0))?
                "the number is divisible both by 5 and 7" : "the number is not divisible by 5 and 7");
        }
    }
}
