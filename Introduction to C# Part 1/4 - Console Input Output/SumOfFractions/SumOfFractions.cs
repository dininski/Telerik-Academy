using System;

namespace SumOfFractions
{
    class SumOfFractions
    {
        static void Main()
        {
            double result = 1;
            double oldsum = 0;
            for (int i = 2; Math.Abs(result - oldsum) > 0.001; i++)
            {
                oldsum = result;
                if (i % 2 == 0)
                {
                    result += (double) (1.0 / i);
                }
                else
                {
                    result -= (double) (1.0 / i);
                }
            }
            Console.WriteLine("{0:0.000}", result);
        }
    }
}
