using System;

namespace Space
{
    public struct Point3D
    {
        public static readonly Point3D startPoint = new Point3D(0, 0, 0);

        public int XPos { get; set; }
        public int YPos { get; set; }
        public int ZPos { get; set; }

        public Point3D(int XPos, int YPos, int ZPos)
            : this()
        {
            this.XPos = XPos;
            this.YPos = YPos;
            this.ZPos = ZPos;
        }

        public static Point3D GetStartingPoint() {
            return startPoint;
        }

        public override string ToString()
        {
            return string.Format("Point coordinates:\nX: {0} Y: {1} Z: {2}", XPos, YPos, ZPos);
        }
    }
}
