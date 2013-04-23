namespace Size_Refactor
{
    using System;

    public class FigureRotator
    {
        public static Figure GetRotatedFigure(Figure figure, double angleOfRotationInRadians)
        {
            double cosOfAngle = Math.Cos(angleOfRotationInRadians);
            double sinOfAngle = Math.Sin(angleOfRotationInRadians);
            double rotatedWidth = (Math.Abs(cosOfAngle) * figure.Width) + (Math.Abs(sinOfAngle) * figure.Height);
            double rotatedHeight = (Math.Abs(sinOfAngle) * figure.Width) + (Math.Abs(cosOfAngle) * figure.Height);
            return new Figure(rotatedWidth, rotatedHeight);
        }
    }
}
