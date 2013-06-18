namespace BinaryRabbits
{
    using System;
    using System.Numerics;

    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            BigInteger result = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    result *= 2;
                }
            }

            Console.WriteLine(result);
        }
    }
}
