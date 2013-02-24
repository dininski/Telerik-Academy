using System;

namespace AllNumbersNotDivisible
{
    class AllNumbersNotDivisible
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                if (i % 21 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
