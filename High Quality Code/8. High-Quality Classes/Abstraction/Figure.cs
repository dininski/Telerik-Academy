namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        /// <summary>
        /// Abstract method that calculates the area of a figure
        /// </summary>
        /// <returns>Returns the area of the figure</returns>
        public abstract double CalcSurface();

        /// <summary>
        /// Abstract method that calculates the perimeter of a figure
        /// </summary>
        /// <returns>Returns the perimeter of the figure</returns>
        public abstract double CalcPerimeter();
    }
}
