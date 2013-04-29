namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the circle radius
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Calculates the perimeter of the circle
        /// </summary>
        /// <returns>Returns the circle perimeter</returns>
        public double CalcPerimeter()
        {
            if (this.Radius == null)
            {
                throw new NullReferenceException("Radius was not set!");
            }

            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        /// Calculates the surface of the circle
        /// </summary>
        /// <returns>Returns the surface of the circle</returns>
        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a string, containing all the string data</returns>
        public override string ToString()
        {
            return string.Format("I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.", this.CalcPerimeter(), this.CalcSurface());
        }
    }
}
