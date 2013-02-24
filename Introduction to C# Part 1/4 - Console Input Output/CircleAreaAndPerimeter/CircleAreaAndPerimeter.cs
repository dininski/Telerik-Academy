using System;

namespace CircleAreaAndPerimeter
{
    class CircleAreaAndPerimeter
    {
        static void Main()
        {
            int radius;
            double area;
            double perimeter;
            Console.WriteLine("Please enter radius:");
            radius = int.Parse(Console.ReadLine());
            area = Math.PI * Math.Pow(radius, 2);
            perimeter = 2 * Math.PI * radius;
            Console.WriteLine("A circle with a radius of {0} has a perimeter of {1:F3} and area of {2:F3}", radius, perimeter, area);
        }
    }
}
