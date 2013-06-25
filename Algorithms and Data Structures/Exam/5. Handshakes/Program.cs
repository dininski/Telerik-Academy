using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _5.Handshakes
{
    class Program
    {
        static BigInteger[] factorials;

        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            factorials = new BigInteger[numberOfPeople + 1];
            int catalan = numberOfPeople / 2;
            factorials[0] = 1;
            factorials[1] = 1;
            Console.WriteLine(Catalan(catalan));
        }

        static BigInteger Catalan(int number)
        {
            return Factorial(2 * number) / (Factorial(number + 1) * Factorial(number));
        }

        static BigInteger Factorial(int number)
        {
            if (factorials[number] != 0)
            {
                return factorials[number];
            }
            else
            {
                factorials[number] = Factorial(number - 1) * number;
                return factorials[number];
            }
        }
    }
}
