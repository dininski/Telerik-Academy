namespace Abstraction
{
    using System;

    /// <summary>
    /// A demo for the Figures, Circle and Rectangle classes
    /// </summary>
    public class FiguresExample
    {
        /// <summary>
        /// The program's main entry point
        /// </summary>
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle);
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(rect);
        }
    }
}
