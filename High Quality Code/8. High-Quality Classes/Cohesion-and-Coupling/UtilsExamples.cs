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

            Box figure = new Box();
            figure.Width = 3;
            figure.Height = 4;
            figure.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", figure.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", figure.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", figure.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", figure.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", figure.CalcDiagonalYZ());
        }
    }
}
