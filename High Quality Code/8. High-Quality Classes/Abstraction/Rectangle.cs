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
        /// Contains the rectangle's width
        /// </summary>
        private double width;

        /// <summary>
        /// Contains the rectangle's height
        /// </summary>
        private double height;

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
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width of the rectangle must be a positive number!");
                }

                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the rectangle
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height of the rectangle must be a positive number!");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Calculates the perimeter of the rectangle
        /// </summary>
        /// <returns>Returns the perimeter of the rectangle</returns>
        public override double CalcPerimeter()
        {
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
