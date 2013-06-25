using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _2._3D_Labyrinth
{
    public class Program
    {
        static char[, ,] building;
        static int colCount;
        static int rowCount;
        static int levelsCount;

        static void Main(string[] args)
        {
            string[] startPosValues = Console.ReadLine().Split(' ');
            int startLevel = int.Parse(startPosValues[0]);
            int startCol = int.Parse(startPosValues[1]);
            int startRow = int.Parse(startPosValues[2]);

            var startPos = new Position(startLevel, startCol, startRow, 0);

            string[] buildingValues = Console.ReadLine().Split(' ');
            levelsCount = int.Parse(buildingValues[0]);
            colCount = int.Parse(buildingValues[1]);
            rowCount = int.Parse(buildingValues[2]);
            building = new char[levelsCount, colCount, rowCount];

            for (int level = 0; level < levelsCount; level++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    string currentLevelValues = Console.ReadLine();

                    for (int row = 0; row < rowCount; row++)
                    {
                        building[level, col, row] = currentLevelValues[row];
                    }
                }
            }

            if (building[startLevel, startCol, startRow] == 'D')
            {
                startPos = new Position(startLevel - 1, startCol, startRow, 1);
            }

            if (building[startLevel, startCol, startRow] == 'U')
            {
                startPos = new Position(startLevel + 1, startCol, startRow, 1);
            }

            Console.WriteLine(StartWalk(startPos));
        }

        public static BigInteger StartWalk(Position start)
        {
            Queue<Position> queue = new Queue<Position>();
            int[,] directions = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Level < 0 || current.Level >= levelsCount)
                {
                    return current.Hops;
                }

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    int nextCol = current.Col + directions[i, 0];
                    int nextRow = current.Row + directions[i, 1];

                    if (nextCol > -1 && nextCol < colCount && nextRow > -1 && nextRow < rowCount)
                    {
                        if (building[current.Level, nextCol, nextRow] == 'U')
                        {
                            var next = new Position(current.Level + 1, nextCol, nextRow, current.Hops + 2);
                            queue.Enqueue(next);
                        }

                        if (building[current.Level, nextCol, nextRow] == 'D')
                        {
                            var next = new Position(current.Level - 1, nextCol, nextRow, current.Hops + 2);
                            queue.Enqueue(next);
                        }

                        if (building[current.Level, nextCol, nextRow] == '.')
                        {
                            var next = new Position(current.Level, nextCol, nextRow, current.Hops + 1);
                            queue.Enqueue(next);
                            building[current.Level, current.Col, current.Row] = '#';
                        }
                    }
                }
            }

            throw new Exception();
        }
    }

    public class Position
    {
        public Position(int level, int col, int row, BigInteger hops)
        {
            this.Level = level;
            this.Col = col;
            this.Row = row;
            this.Hops = hops;
        }

        public int Level { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }
        public BigInteger Hops { get; set; }
    }
}