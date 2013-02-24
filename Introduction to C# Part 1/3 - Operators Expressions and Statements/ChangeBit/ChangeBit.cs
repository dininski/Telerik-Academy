using System;

namespace ChangeBit
{
    class ChangeBit
    {
        static void Main()
        {
            int p;
            int v;
            int n;

            Console.WriteLine("Please enter an integer number: ");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter 1 or 0: ");
            v = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter position to change: ");
            p = int.Parse(Console.ReadLine());

            if ((1 & (n >> p)) == v)
            {
                Console.WriteLine("Nothing to change");
            }
            else if (v == 0)
            {
                n = n & (~(1 << p));
            }
            else if (v == 1)
            {
                n = n | (1 << p);
            }
            Console.WriteLine("N = {0}, with {1} at position {2}", n, v, p);
        }
    }
}
