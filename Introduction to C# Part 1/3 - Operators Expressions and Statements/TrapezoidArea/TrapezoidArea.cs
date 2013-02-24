using System;

namespace TrapezoidArea
{
    class TrapezoidArea
    {
        static void Main()
        {
            double height;
            double sideA;
            double sideB;
            double area;
            Console.WriteLine("Please enter height:");
            height = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter side a:");
            sideA = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter side b:");
            sideB = double.Parse(Console.ReadLine());

            area = 0.5 * height * (sideA + sideB);
            Console.WriteLine("The area of the trapezoid is {0}", area);
        }
    }
}
