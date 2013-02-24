using System;

namespace Exercise11
{
    class SwapNumbers
    {
        static void Main()
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("a={0} b={1}",a,b);
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine("a={0} b={1}", a, b);
        }
    }
}
