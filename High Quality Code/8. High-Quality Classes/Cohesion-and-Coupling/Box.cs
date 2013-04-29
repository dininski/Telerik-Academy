namespace CohesionAndCoupling
{
    using System;
    using CohesionAndCoupling.Utils;

    /// <summary>
    /// A class, which describes a box
    /// </summary>
    public class Box
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

        /// <summary>
        /// Calculates a diagonal
        /// </summary>
        /// <returns></returns>
        public double CalcDiagonalXYZ()
        {
            double distance = GeometryUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
