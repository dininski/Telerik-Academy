using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int N, M, P, a, b;

        int.TryParse(Console.ReadLine(), out N);
        int.TryParse(Console.ReadLine(), out M);
        int.TryParse(Console.ReadLine(), out P);
        int.TryParse(Console.ReadLine(), out a);
        int.TryParse(Console.ReadLine(), out b);
        for (int i = 1; ; i++)
        {
            int counter = 0;
            if (i % N == 0) counter++;
            if (i % b == 0) counter++;
            if (i % M == 0) counter++;
            if (i % P == 0) counter++;
            if (i % a == 0) counter++;
            if (counter >= 3)
            {
                Console.WriteLine(i);
                return;
            }
        }

    }
}