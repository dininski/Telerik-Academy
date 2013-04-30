namespace CohesionAndCoupling
{
    using System;
    using Utils;

    /// <summary>
    /// A demo of the Cohesion-and-Coupling utilities.
    /// </summary>
    public class UtilsExamples
    {
        /// <summary>
        /// The main entry point of the program
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(FileSystemUtils.GetFileExtension("example"));
            Console.WriteLine(FileSystemUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileSystemUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileSystemUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileSystemUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileSystemUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}", GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Shape shape = new Shape();
            shape.Width = 3;
            shape.Height = 4;
            shape.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", shape.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", GeometryUtils.CalcDistance3D(0, 0, 0, shape.Width, shape.Height, shape.Depth));
            Console.WriteLine("Diagonal XY = {0:f2}", GeometryUtils.CalcDistance2D(0, 0, shape.Width, shape.Height));
            Console.WriteLine("Diagonal XZ = {0:f2}", GeometryUtils.CalcDistance2D(0, 0, shape.Width, shape.Depth));
            Console.WriteLine("Diagonal YZ = {0:f2}", GeometryUtils.CalcDistance2D(0, 0, shape.Height, shape.Depth));
        }
    }
}
