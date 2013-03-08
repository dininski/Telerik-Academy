using System;

namespace Geometry
{
    public class Circle : Shape
    {
        public Circle(double width)
            : base(width, width)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * Width * Width;
        }
    }
}
