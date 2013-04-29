namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
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

        public override string ToString()
        {
            return string.Format("I am a rectangle. My perimeter is {0:f2}. My surface is {1:f2}.", this.CalcPerimeter(), this.CalcSurface());
        }
    }
}
