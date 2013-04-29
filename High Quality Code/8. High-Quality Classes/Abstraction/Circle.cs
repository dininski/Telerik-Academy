namespace Abstraction
{
    using System;

    /// <summary>
    /// A circle class, that can calculate it's perimeter and
    /// radius.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// The circle's radius
        /// </summary>
        private double radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class and
        /// sets the <see cref="Circle"/>'s radius
        /// </summary>
        /// <param name="radius">Sets the circle's radius</param>
        public Circle(double radius)
        {
            this.Radius = radius;
            this.FigureType = "circle";
        }

        /// <summary>
        /// Gets or sets the circle radius
        /// </summary>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The radius cannot be negative!");
                }

                this.radius = value;
            }
        }

        /// <summary>
        /// Calculates the perimeter of the circle
        /// </summary>
        /// <returns>Returns the circle perimeter</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        /// Calculates the surface of the circle
        /// </summary>
        /// <returns>Returns the surface of the circle</returns>
        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
