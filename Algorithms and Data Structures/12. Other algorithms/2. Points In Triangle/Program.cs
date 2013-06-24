// You are given 3 points A, B and C, forming triangle, and a point P.
// Check if the point P is in the triangle or not.


namespace PointsInTriangle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // Points should be entered in the format '1 2'.
            // For example entering 1 2 will create a new Point with x = 1 and y = 2
            Console.WriteLine("Enter point coordinates in the format '1 2' for point with coordinates x = 1 and y = 2");
            Console.Write("Please enter coordinates of the first triangle point: ");
            Point A = Point.Parse(Console.ReadLine());
            Console.Write("Please enter coordinates of the second triangle point: ");
            Point B = Point.Parse(Console.ReadLine());
            Console.Write("Please enter coordinates of the third triangle point: ");
            Point C = Point.Parse(Console.ReadLine());

            Console.WriteLine("Please enter coordinates of the point for which to determine if it is in the triangle: ");
            Point N = Point.Parse(Console.ReadLine());


        }
    }
}
