namespace Methods.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    public class Geometry
    {
        /// <summary>
        /// Calculates the area of a triangle by three given sides <paramref name="a"/>,
        /// <paramref name="b"/> and <paramref name="c"/>
        /// </summary>
        /// <param name="a">First side length</param>
        /// <param name="b">Second side length</param>
        /// <param name="c">Third side length</param>
        /// <returns>Returns the area of the triangle</returns>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Every side should be positive.");
            }

            if (!CanFormTriangle(a, b, c))
            {
                throw new ArgumentException("The provided sides cannot form a triangle!");
            }

            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
            return area;
        }

        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="x1">X coordinates of the first point</param>
        /// <param name="y1">Y coordinates of the first point</param>
        /// <param name="x2">X coordinates of the second point</param>
        /// <param name="y2">Y coordinates of the second point</param>
        /// <returns></returns>
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        /// <summary>
        /// Checks if two directions coincide
        /// </summary>
        /// <param name="firstPoint">First direction</param>
        /// <param name="secondPoint">Second direction</param>
        /// <returns></returns>
        public static bool PointHasSameDirection(double firstPoint, double secondPoint)
        {
            return firstPoint == secondPoint;
        }

        /// <summary>
        /// Checks if a triangle can be formed using <paramref name="a"/>, <paramref name="b"/>
        /// and <paramref name="c"/> as sides.
        /// </summary>
        /// <param name="a">First side length</param>
        /// <param name="b">Second side length</param>
        /// <param name="c">Third side length</param>
        /// <returns>Return true is the sides can form a triangle and false if they cannot</returns>
        private static bool CanFormTriangle(double a, double b, double c)
        {
            return (a + b > c) & (a + c > b) && (b + c > a);
        }
    }
}
