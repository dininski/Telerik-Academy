namespace Labyrinth
{
    public class Position
    {
        public Position(int col, int row, int stepsSoFar)
        {
            this.Col = col;
            this.Row = row;
            this.Steps = stepsSoFar;
        }

        public int Steps { get; set; }

        public int Col { get; set; }

        public int Row { get; set; }
    }
}
