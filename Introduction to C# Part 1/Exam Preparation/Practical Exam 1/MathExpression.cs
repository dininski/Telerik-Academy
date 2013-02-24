using System;

    class Program
    {
        static void Main()
        {
            double result;
            double N, M, P;
            Double.TryParse(Console.ReadLine(), out N);
            Double.TryParse(Console.ReadLine(), out M);
            Double.TryParse(Console.ReadLine(), out P);
            result = (N * N + 1 / (M * P) + 1337) / (N - 128.523123123 * P) + Math.Sin((int)(M % 180.0));
            Console.WriteLine("{0:0.000000}", result);
        }
    }

