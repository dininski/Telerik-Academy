namespace Abstraction
{
    using System;

    /// <summary>
    /// An abstract class that models a figure and provides methods
    /// for calculating the perimeter and the surface.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Gets or sets information regarding the figure type
        /// </summary>
        protected string FigureType { get; set; }

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

        /// <summary>
        /// Returns a descriptive string, containing the figure type,
        /// perimeter and surface.
        /// </summary>
        /// <returns>A descriptive string of the figure.</returns>
        public override string ToString()
        {
            return string.Format("I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.", this.FigureType, this.CalcPerimeter(), this.CalcSurface());
        }
    }
}
