namespace LargestConnectedArea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static char[,] maze;
        static List<Tuple<int, int>> currentPath;
        static int connectedLength;
        static int maxConnected;

        public static void Main(string[] args)
        {
            currentPath = new List<Tuple<int, int>>();
            connectedLength = 0;
            maxConnected = 0;

            maze = new char[,]
            {
                {'o' , 'x' , 'o' , 'o' , 'o' , 'o' , 'o'}, // maze start is at {0,3}
                {'o' , 'x' , 'x' , 'x' , 'o' , 'x' , 'o'},
                {'o' , 'o' , 'x' , 'x' , 'o' , 'o' , 'o'},
                {'x' , 'o' , 'o' , 'x' , 'o' , 'x' , 'o'},
                {'o' , 'x' , 'o' , 'x' , 'o' , 'x' , 'o'},
                {'o' , 'o' , 'x' , 'o' , 'o' , 'o' , 'o'}, // maze exit is at {5,6};
                {'o' , 'o' , 'o' , 'x' , 'x' , 'x' , 'o'}
            };

            for (int col = 0; col < maze.GetLength(0); col++)
            {
                for (int row = 0; row < maze.GetLength(1); row++)
                {
                    FindPaths(col, row);
                    if (maxConnected < connectedLength)
                    {
                        maxConnected = connectedLength;
                    }

                    connectedLength = 0;
                }
            }

            Console.WriteLine("The longest path is: {0}", maxConnected);
        }

        public static void FindPaths(int col, int row)
        {
            if (!IsValidPosition(col, row))
            {
                return;
            }

            if (maze[col, row] != 'o')
            {
                return;
            }

            currentPath.Add(new Tuple<int, int>(col, row));

            maze[col, row] = 'v';
            connectedLength++;

            PrintMatrix();
            System.Threading.Thread.Sleep(500);
            Console.Clear();

            FindPaths(col + 1, row);
            FindPaths(col - 1, row);
            FindPaths(col, row + 1);
            FindPaths(col, row - 1);

            currentPath.Remove(currentPath.Last());
        }

        public static bool IsValidPosition(int col, int row)
        {
            if (row >= 0 && col >= 0 && col < maze.GetLength(0) && row < maze.GetLength(1))
            {
                return true;
            }

            return false;
        }

        public static void PrintMatrix()
        {
            for (int col = 0; col < maze.GetLength(0); col++)
            {
                for (int row = 0; row < maze.GetLength(1); row++)
                {
                    if (maze[col, row] == 'v')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", maze[col, row]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write("{0} ", maze[col, row]);
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Current path length: {0} ", connectedLength);
        }
    }
}
