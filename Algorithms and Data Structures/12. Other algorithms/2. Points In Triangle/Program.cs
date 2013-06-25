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
            Point trianglePointA = Point.Parse(Console.ReadLine());
            Console.Write("Please enter coordinates of the second triangle point: ");
            Point trianglePointB = Point.Parse(Console.ReadLine());
            Console.Write("Please enter coordinates of the third triangle point: ");
            Point trianglePointC = Point.Parse(Console.ReadLine());

            Console.WriteLine("Please enter coordinates of the point for which to determine if it is in the triangle: ");
            Point PointToCheck = Point.Parse(Console.ReadLine());

            double dx = PointToCheck.XCoords - trianglePointC.XCoords;
            double dy = PointToCheck.YCoords - trianglePointC.YCoords;

            double a = trianglePointA.XCoords - trianglePointC.XCoords;
            double b = trianglePointA.YCoords - trianglePointC.YCoords;
            double c = trianglePointB.XCoords - trianglePointC.XCoords;
            double d = trianglePointB.YCoords - trianglePointC.YCoords;

            double denominator = a * d - b * c;

            double alpha = d * dx - c * dy;
            alpha = alpha / denominator;

            double beta = a * dy - b * dx;
            beta = beta / denominator;

            double gamma = 1.0 - (alpha + beta);

            if (alpha >= 0 && beta >= 0 && gamma >= 0)
            {
                Console.WriteLine("Point with coordinates ({0}, {1}) lies within the triangle", PointToCheck.XCoords, PointToCheck.YCoords);
            }
            else
            {
                Console.WriteLine("Point with coordinates ({0}, {1}) does not lie within the triangle", PointToCheck.XCoords, PointToCheck.YCoords);
            }

        }
    }
}