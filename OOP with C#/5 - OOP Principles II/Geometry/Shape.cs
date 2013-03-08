using System;

namespace Geometry
{
    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Shape(double width, double height)
        {
            Height = height;
            Width = width;
        }

        public abstract double CalculateSurface();

    }
}
