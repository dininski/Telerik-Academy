using System;

namespace Geometry
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (Width * Height) / 2;
        }
    }
}
