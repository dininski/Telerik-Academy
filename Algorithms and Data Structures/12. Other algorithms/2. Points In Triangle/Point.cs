namespace PointsInTriangle
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.XCoords = x;
            this.YCoords = y;
        }

        public static Point Parse(string input)
        {
            var inputStrings = input.Split(' ');
            int x = int.Parse(inputStrings[0]);
            int y = int.Parse(inputStrings[1]);

            return new Point(x, y);
        }

        public int XCoords { get; set; }
        public int YCoords { get; set; }
    }
}
