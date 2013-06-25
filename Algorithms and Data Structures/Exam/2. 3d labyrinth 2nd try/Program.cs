using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3d_labyrinth_2nd_try
{
    class Program
    {
        static char[, ,] labyrinth;
        static int levelsCount;
        static int rowsCount;
        static int colsCount;

        static void Main(string[] args)
        {
            string[] startPosString = Console.ReadLine().Split(' ');

            int startLevel = int.Parse(startPosString[0]);
            int startRow = int.Parse(startPosString[1]);
            int startCol = int.Parse(startPosString[2]);

            var startPos = new Position(startLevel, startRow, startCol, 0);

            string[] labyrinthSize = Console.ReadLine().Split(' ');
            levelsCount = int.Parse(labyrinthSize[0]);
            rowsCount = int.Parse(labyrinthSize[1]);
            colsCount = int.Parse(labyrinthSize[2]);

            labyrinth = new char[levelsCount, rowsCount, colsCount];

            for (int level = 0; level < levelsCount; level++)
            {
                for (int row = 0; row < rowsCount; row++)
                {
                    string currentRow = Console.ReadLine();

                    for (int col = 0; col < colsCount; col++)
                    {
                        labyrinth[level, row, col] = currentRow[col];
                    }
                }
            }

            Queue<Position> bfs = new Queue<Position>();
            bfs.Enqueue(startPos);

            while (bfs.Count > 0)
            {
                var current = bfs.Dequeue();

                if (current.Level < 0 || current.Level == levelsCount)
                {
                    Console.WriteLine(current.Jumps);
                    return;
                }

                if (labyrinth[current.Level, current.Row, current.Col] == 'U')
                {
                    bfs.Enqueue(new Position(current.Level + 1, current.Row, current.Col, current.Jumps + 1));
                }

                if (labyrinth[current.Level, current.Row, current.Col] == 'D')
                {
                    bfs.Enqueue(new Position(current.Level - 1, current.Row, current.Col, current.Jumps + 1));
                }

                if (labyrinth[current.Level, current.Row, current.Col] == '.')
                {
                    int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };

                    for (int i = 0; i < directions.GetLength(0); i++)
                    {
                        int nextCol = current.Col + directions[i, 0];
                        int nextRow = current.Row + directions[i, 1];

                        if (nextCol > -1 && nextCol < colsCount && nextRow > -1 && nextRow < rowsCount)
                        {
                            bfs.Enqueue(new Position(current.Level, nextRow, nextCol, current.Jumps + 1));
                        }
                    }
                }

                labyrinth[current.Level, current.Row, current.Col] = '#';
            }
        }
    }

    public class Position
    {
        public Position(int level, int row, int col, int jumps)
        {
            this.Level = level;
            this.Row = row;
            this.Col = col;
            this.Jumps = jumps;
        }

        public int Level { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public int Jumps { get; set; }
    }
}
