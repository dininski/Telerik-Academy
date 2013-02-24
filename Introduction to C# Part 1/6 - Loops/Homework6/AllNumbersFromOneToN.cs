using System;

namespace Homework6
{
    class AllNumbersFromOneToN
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
