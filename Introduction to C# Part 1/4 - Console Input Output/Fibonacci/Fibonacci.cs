using System;
using System.Numerics;

namespace Fibonacci
{
    class Fibonacci
    {
        static void Main()
        {
            BigInteger a=0;
            BigInteger b=1;
            for (int i = 1; i <= 100; i++)
            {
                Console.Write(a + " ");
                a = a+b;
                b = a - b;
            }
        }
    }
}
