namespace _3.Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static int best;
        static int bestDivisorsCount;
        static int[] numbers;

        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            bestDivisorsCount = int.MaxValue;
            numbers = new int[numbersCount];
            best = int.MaxValue;

            for (int i = 0; i < numbersCount; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            GeneratePerm(numbers, 0);
            Console.WriteLine(best);
        }

        static int FindDivisorCount(int number)
        {
            int divisorCount = 0;

            for (int i = 1; i < (number + 2) / 2; i++)
            {
                if (number % i == 0)
                {
                    divisorCount++;
                }
            }

            return divisorCount + 1;
        }

        static void GeneratePerm(int[] numbers, int k)
        {
            if (k >= numbers.Length)
            {
                int number = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    number += numbers[i] * (int)Math.Pow(10, i);
                }

                int currentDiv = FindDivisorCount(number);

                if (currentDiv < bestDivisorsCount)
                {
                    bestDivisorsCount = currentDiv;
                    best = number;
                } else if(currentDiv == bestDivisorsCount) {
                    if (best > number)
                    {
                        best = number;
                    }

                    //best = number;
                }
            }
            else
            {
                GeneratePerm(numbers, k + 1);
                for (int i = k + 1; i < numbers.Length; i++)
                {
                    Swap(ref numbers[k], ref numbers[i]);
                    GeneratePerm(numbers, k + 1);
                    Swap(ref numbers[k], ref numbers[i]);
                }
            }
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
