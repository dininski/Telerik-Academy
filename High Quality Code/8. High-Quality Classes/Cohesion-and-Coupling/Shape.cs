namespace CohesionAndCoupling
{
    using System;
    using CohesionAndCoupling.Utils;

    /// <summary>
    /// A class, which describes a box
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Gets or sets the width of the box
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the box
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the depth of the box
        /// </summary>
        public double Depth { get; set; }

        /// <summary>
        /// Calculates the volume of the box
        /// </summary>
        /// <returns>Return the volume of the box</returns>
        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }
    }
}
