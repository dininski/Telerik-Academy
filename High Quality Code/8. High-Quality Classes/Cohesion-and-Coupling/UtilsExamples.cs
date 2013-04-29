namespace CohesionAndCoupling
{
    using System;
    using Utils;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileSystemUtils.GetFileExtension("example"));
            Console.WriteLine(FileSystemUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileSystemUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileSystemUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileSystemUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileSystemUtils.GetFileNameWithoutExtension("example.new.pdf"));

            // Console.WriteLine("Distance in the 2D space = {0:f2}",
            //     Figure.CalcDistance2D(1, -2, 3, 4));
            // Console.WriteLine("Distance in the 3D space = {0:f2}",
            //     Figure.CalcDistance3D(5, 2, -1, 3, -6, 4));
               
            // Figure.Width = 3;
            // Figure.Height = 4;
            // Figure.Depth = 5;
            // Console.WriteLine("Volume = {0:f2}", Figure.CalcVolume());
            // Console.WriteLine("Diagonal XYZ = {0:f2}", Figure.CalcDiagonalXYZ());
            // Console.WriteLine("Diagonal XY = {0:f2}", Figure.CalcDiagonalXY());
            // Console.WriteLine("Diagonal XZ = {0:f2}", Figure.CalcDiagonalXZ());
            // Console.WriteLine("Diagonal YZ = {0:f2}", Figure.CalcDiagonalYZ());
        }
    }
}
