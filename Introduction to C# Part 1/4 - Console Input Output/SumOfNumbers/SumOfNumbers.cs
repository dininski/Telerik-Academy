using System;

namespace SumOfNumbers
{
    class SumOfNumbers
    {
        static void Main()
        {
            int sum=0;
            int n=0;
            while (true)
            {
                Console.WriteLine("Please enter a number to add:");
                if (int.TryParse(Console.ReadLine(), out n)) 
                {
                    sum+=n;
                    Console.WriteLine("The sum so far is: {0}", sum);
                }
            }

        }
    }
}
