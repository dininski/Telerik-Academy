namespace ColorBallsCombinations
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Program
    {
        static Dictionary<char, int> occurences;
        static BigInteger comb;
        static Dictionary<int, BigInteger> factorials;

        public static void Main(string[] args)
        {
            comb = 0;
            string ballsInput = Console.ReadLine();
            occurences = new Dictionary<char, int>();
            factorials = new Dictionary<int, BigInteger>();

            factorials.Add(1, 1);
            factorials.Add(2, 2);

            foreach (var ball in ballsInput)
            {
                if (!occurences.ContainsKey(ball))
                {
                    occurences.Add(ball, 0);
                }

                occurences[ball]++;
            }

            comb = PossibleCombinations(ballsInput.Length, occurences);
            Console.WriteLine(comb);
        }

        public static BigInteger PossibleCombinations(int total, Dictionary<char, int> repetitions)
        {
            BigInteger denominator = 1;

            foreach (var occurence in occurences)
            {
                denominator *= Factorial(occurence.Value);
            }

            return Factorial(total) / denominator;
        }

        public static BigInteger Factorial(int number)
        {
            if (!factorials.ContainsKey(number))
            {
                factorials.Add(number, number * Factorial(number - 1));
            }

            return factorials[number];
        }
    }
}