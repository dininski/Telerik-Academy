namespace Methods
{
    using System;
    using Utilities;
    using University;

    public class DemoProgram
    {
        public static void Main()
        {
            Console.WriteLine(Geometry.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(TextOperations.GetNumberAsWord(5));

            Console.WriteLine(Algebra.FindMax(5, -1, 3, 2, 14, 2, 3));

            ConsolePrinter.PrintFloatWithPrecision(1.3);
            ConsolePrinter.PrintNumberAsPercent(0.75);
            ConsolePrinter.PrinNumbertWithOffset(2.30, 8);

            Console.WriteLine(Geometry.CalculateDistance(3, -1, 3, 2.5));
            bool horizontal;
            bool vertical;
            horizontal = Geometry.PointHasSameDirection(3, 3);
            vertical = Geometry.PointHasSameDirection(-1, 2.5);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.ExtraInfo = "From Sofia";
            peter.DateOfBirth = DateTime.Parse("03/17/1992");

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.ExtraInfo = "From Vidin, gamer, high results";
            stella.DateOfBirth = DateTime.Parse("11/03/1993");

            Console.WriteLine("{0} is older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
