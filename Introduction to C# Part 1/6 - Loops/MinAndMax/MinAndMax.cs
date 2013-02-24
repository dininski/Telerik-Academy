using System;

namespace MinAndMax
{
    class MinAndMax
    {
        static void Main()
        {
            int min;
            int max;
            Console.WriteLine("Enter a base value:");
            int userInput = int.Parse(Console.ReadLine());
            min = max = userInput;
            while (true)
            {
                Console.WriteLine("Enter an integer:");
                userInput = int.Parse(Console.ReadLine());
                if (userInput > max)
                {
                    max = userInput;
                }

                if (userInput < min)
                {
                    min = userInput;
                }

                Console.WriteLine("The smallest integer that you have entered is {0} and the largest is {1}", min, max);
            }
        }
    }
}
