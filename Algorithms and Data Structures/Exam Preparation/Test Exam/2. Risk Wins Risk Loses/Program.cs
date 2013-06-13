namespace _2.Risk_Wins_Risk_Loses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] matrix = new int[100, 1000];

            Position start = Position.Parse(Console.ReadLine());
            matrix[start.Col, start.Row] = 1;

            Position dest = Position.Parse(Console.ReadLine());
            matrix[dest.Col, dest.Row] = -2;

            int occupiedCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < occupiedCount; i++)
            {
                Position occ = Position.Parse(Console.ReadLine());
                matrix[occ.Col, occ.Row] = -1;
            }

            int[] moveDirections = new int[] { 1, -1, -10, 10, 100, -100 };

            var positions = new Queue<Position>();
            positions.Enqueue(start);

            if (dest.Col == start.Col && dest.Row == start.Row)
            {
                Console.WriteLine(0);
                return;
            }

            while (positions.Count != 0)
            {
                var current = positions.Dequeue();
                int currentCol = current.Col;
                int currentRow = current.Row;

                for (int i = 0; i < 6; i++)
                {
                    int colDir;
                    int rowDir;

                    if (i % 2 == 0)
                    {
                        colDir = 0;
                        rowDir = moveDirections[i];
                    }
                    else
                    {
                        colDir = moveDirections[i];
                        rowDir = 0;
                    }


                    if ((currentCol + colDir > -1) &&
                        (currentRow + rowDir > -1))
                    {
                        if ((currentCol + colDir < 100) && (currentRow + rowDir < 1000))
                        {
                            if (matrix[currentCol + colDir, currentRow + rowDir] == -2)
                            {
                                Console.WriteLine(matrix[currentCol, currentRow]);
                                return;
                            }
                            if (matrix[currentCol + colDir, currentRow + rowDir] == 0)
                            {
                                matrix[currentCol + colDir, currentRow + rowDir] = matrix[currentCol, currentRow] + 1;
                                positions.Enqueue(new Position(currentCol + colDir, currentRow + rowDir));
                            }
                        }
                    }
                }
            }

            Console.WriteLine(-1);
        }

        private class Position
        {
            public int Col { get; set; }
            public int Row { get; set; }

            public Position(int col, int row)
            {
                this.Col = col;
                this.Row = row;
            }

            public static Position Parse(string input)
            {
                int destination = int.Parse(input);
                int destCol = destination / 1000;
                int destRow = destination % 1000;
                return new Position(destCol, destRow);
            }
        }
    }
}
