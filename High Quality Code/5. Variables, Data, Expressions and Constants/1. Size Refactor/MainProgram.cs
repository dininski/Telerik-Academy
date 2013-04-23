namespace Size_Refactor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MainProgram
    {
        public static void Main()
        {
            Figure rectangle = new Figure(10, 20);
            Figure rotatedRectangle = FigureRotator.GetRotatedFigure(rectangle, 2);
            Console.WriteLine("Rotated figure width: {0} and height: {1}", rotatedRectangle.Width, rotatedRectangle.Height);
        }
    }
}
