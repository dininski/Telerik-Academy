namespace Abstraction
{
    using System;

    /// <summary>
    /// A rectangle, which has methods to calculate it's surface
    /// and perimeter
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class
        /// and sets it's <paramref name="width"/> and <paramref name="height"/>
        /// </summary>
        /// <param name="width">Sets the rectangle's width</param>
        /// <param name="height">Sets the rectangle's height</param>
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
            this.FigureType = "rectangle";
        }

        /// <summary>
        /// Gets or sets the width of the rectangle
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Calculates the perimeter of the rectangle
        /// </summary>
        /// <returns>Returns the perimeter of the rectangle</returns>
        public override double CalcPerimeter()
        {
            if (this.Width <= 0 || this.Height <= 0)
            {
                throw new Exception("The rectangle cannot have a side that is null!");
            }

            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        /// Calculates the surface of the rectangle
        /// </summary>
        /// <returns>Returns the surface of the rectangle</returns>
        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
