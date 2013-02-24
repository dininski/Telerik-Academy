using System;

namespace PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main()
        {
            int number;
            bool isPrime = true;
            Console.WriteLine("Please enter number:");
            number = int.Parse(Console.ReadLine());
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                }
            }
            if (isPrime)
            {
                Console.WriteLine("The number {0} is Prime", number);
            }
            else
            {
                Console.WriteLine("The number {0} isn't Prime", number);
            }
        }
    }
}
