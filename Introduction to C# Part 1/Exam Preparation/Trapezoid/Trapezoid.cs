using System;

class Trapezoid
{
    static void Main()
    {
        int N;
        int.TryParse(Console.ReadLine(), out N);
        int position = 0;
        for (int i = 0; i < N + 1; i++)
        {
            string trapezoid = "*";
            if (i == 0)
            {
                trapezoid = trapezoid.PadLeft(N + 1, '.') + trapezoid.PadLeft(N - 1, '*');
            }
            else if (i == N)
            {
                trapezoid = trapezoid.PadLeft(2 * N, '*');
            }
            else
            {
                trapezoid = trapezoid.PadLeft(N - position, '.') + trapezoid.PadLeft(N + position, '.');
                position++;
            }

            Console.WriteLine(trapezoid);
        }
    }
}