using System;

namespace Galaxian.Common
{
    public class Coordinates
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Coordinates(int XPosition, int YPosition)
        {
            this.XPosition = XPosition;
            this.YPosition = YPosition;
        }

        //Overloading the + and - operators for easy summation and subtraction of Coordinates 

        public static Coordinates operator +(Coordinates first, Coordinates second)
        {
            return new Coordinates(first.XPosition + second.XPosition, first.YPosition + second.YPosition);
        }

        public static Coordinates operator -(Coordinates first, Coordinates second)
        {
            return new Coordinates(first.XPosition - second.XPosition, first.YPosition - second.YPosition);
        }
    }
}
