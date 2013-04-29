namespace CohesionAndCoupling.Utils
{
    using System;

    /// <summary>
    /// A set of geometry utilities, that can calculate the distance
    /// between two points in two dimensional or three dimensional
    /// environment.
    /// </summary>
    public static class GeometryUtils
    {
        /// <summary>
        /// Calculates the distance between two points in two dimensional space
        /// </summary>
        /// <param name="x1">X coordinates of the first point</param>
        /// <param name="y1">Y coordinates of the first point</param>
        /// <param name="x2">X coordinates of the second point</param>
        /// <param name="y2">Y coordinates of the second point</param>
        /// <returns>Returns the distance between two points in two dimensional space</returns>
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        /// <summary>
        /// Calculates the distance between two points in three dimensional space
        /// </summary>
        /// <param name="x1">X coordinates of the first point</param>
        /// <param name="y1">Y coordinates of the first point</param>
        /// <param name="z1">Z coordinates of the first point</param>
        /// <param name="x2">X coordinates of the second point</param>
        /// <param name="y2">Y coordinates of the second point</param>
        /// <param name="z2">Z coordinates of the second point</param>
        /// <returns>Returns the distance between two points in three dimensional space</returns>
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
            return distance;
        }
    }
}
