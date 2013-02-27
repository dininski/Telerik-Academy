using System;
using System.Collections.Generic;

namespace Space
{
    [Version(1,0)]
    public class Path
    {
        private List<Point3D> pathPoints = new List<Point3D>();

        public void AddPoint(Point3D point)
        {
            pathPoints.Add(point);
        }

        public List<Point3D> GetPath()
        {
            return new List<Point3D>(pathPoints);
        }
    }
}
