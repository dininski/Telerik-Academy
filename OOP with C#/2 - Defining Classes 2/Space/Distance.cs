using System;

namespace Space
{
    public static class Distance
    {
        public static double DistanceBetweenPoints(Point3D firstPoint, Point3D secondPoint)
        {
            double deltaX = firstPoint.XPos - secondPoint.XPos; 
            double deltaY = firstPoint.YPos - secondPoint.YPos;
            double deltaZ = firstPoint.ZPos - secondPoint.ZPos;
            return Math.Sqrt(deltaX*deltaX + deltaY*deltaY + deltaZ*deltaZ);
        }
    }
}
