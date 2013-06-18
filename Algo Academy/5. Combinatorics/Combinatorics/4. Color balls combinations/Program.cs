namespace _4.Color_balls_combinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static Dictionary<int, BigInteger> factorials;
        static HashSet<char> occurences;

        public static void Main(string[] args)
        {
            factorials = new Dictionary<int, BigInteger>();
            factorials.Add(1, 1);
            factorials.Add(2, 2);
            string input = Console.ReadLine();
            int numberOfBalls = input.Length;
            occurences = new HashSet<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!occurences.Contains(input[i]))
                {
                    occurences.Add(input[i]);
                }
            }

            int numberOfColors = occurences.Count;
            Console.WriteLine(Factorial(numberOfBalls) / (Factorial(numberOfColors) * Factorial(numberOfBalls - numberOfColors)));
        }

        public static BigInteger Factorial(int number)
        {
            if (factorials.ContainsKey(number))
            {
                return factorials[number];
            }

            BigInteger fact = number * Factorial(number - 1);
            factorials.Add(number, fact);
            return fact;
        }
    }
}