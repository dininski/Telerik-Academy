using System;

namespace Homework4
{
    class SumOfThreeInts
    {
        static void Main()
        {
            int first;
            int second;
            int third;
            int sum;
            Console.WriteLine("Please enter the first int:");
            first = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the second int:");
            second = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the third int:");
            third = int.Parse(Console.ReadLine());
            sum = first + second + third;
            Console.WriteLine("The sum of {0}, {1} and {2} is {3}", first, second, third, sum);
        }
    }
}
