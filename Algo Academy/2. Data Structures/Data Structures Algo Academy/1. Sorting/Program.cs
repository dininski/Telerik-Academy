using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sorting
{
    class Program
    {
        public static long divider;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] input2 = input.Split(' ');
            int totalNums = int.Parse(input2[0]);
            divider = long.Parse(input2[1]);
            long[] numbersToSort = new long[totalNums];
            string numbers = Console.ReadLine();
            string[] number2 = numbers.Split(' ');

            for (int i = 0; i < totalNums; i++)
            {
                numbersToSort[i] = long.Parse(number2[i]);
            }

            Array.Sort(numbersToSort, (x, y) => Comparison(x, y));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < totalNums - 1; i++)
            {
                sb.AppendFormat("{0} ", numbersToSort[i]);
            }

            sb.AppendFormat("{0} ", numbersToSort[totalNums - 1]);
            Console.WriteLine(sb.ToString());
        }

        public static int Comparison(long x, long y)
        {
            int result = (x % divider).CompareTo(y % divider);
            if (result == 0)
            {
                return x.CompareTo(y);
            }
            else
            {
                return result;
            }
        }
    }
}