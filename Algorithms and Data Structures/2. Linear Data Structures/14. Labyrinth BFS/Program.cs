// * We are given a labyrinth of size N x N. Some of its
// cells are empty (0) and some are full (x). We can move 
// from an empty cell to another empty cell if they share 
// common wall. Given a starting position (*) calculate and 
// fill in the array the minimal distance from this position
// to any other cell in the array. Use "u" for all 
// unreachable cells. 

namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] maze = new string[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" }
            };                                 

            string[,] solvedMaze = Solve(maze);
            Console.WriteLine(ArrayToString(solvedMaze));
        }

        public static string[,] Solve(string[,] startingMaze)
        {
            string[,] solutionMaze = CopyArray(startingMaze);
            Bfs(solutionMaze);
            AddUnreachable(solutionMaze);
            return solutionMaze;
        }

        public static void AddUnreachable(string[,] solutionMaze)
        {
            for (int col = 0; col < solutionMaze.GetLength(0); col++)
            {
                for (int row = 0; row < solutionMaze.GetLength(1); row++)
                {
                    if (solutionMaze[col, row] == "0")
                    {
                        solutionMaze[col, row] = "u";
                    }
                }
            }
        }

        public static void Bfs(string[,] maze)
        {
            Stack<Position> positionQueue = new Stack<Position>();

            Position startPosition = FindStartPosition(maze);

            positionQueue.Push(startPosition);

            while (positionQueue.Count != 0)
            {
                Position currentPosition = positionQueue.Pop();
                int currentCol = currentPosition.Col;
                int currentRow = currentPosition.Row;
                int steps = currentPosition.Steps;
                if (currentPosition == startPosition)
                {
                    maze[currentCol, currentRow] = "*";
                }
                else
                {
                    maze[currentCol, currentRow] = steps.ToString();
                }

                if (currentCol > 0 && maze[currentCol - 1, currentRow] == "0")
                {
                    positionQueue.Push(new Position(currentCol - 1, currentRow, steps + 1));
                }

                if (currentRow > 0 && maze[currentCol, currentRow - 1] == "0")
                {
                    positionQueue.Push(new Position(currentCol, currentRow - 1, steps + 1));
                }

                if (currentCol < maze.GetLength(0) - 1 && maze[currentCol + 1, currentRow] == "0")
                {
                    positionQueue.Push(new Position(currentCol + 1, currentRow, steps + 1));
                }

                if (currentRow < maze.GetLength(1) - 1 && maze[currentCol, currentRow + 1] == "0")
                {
                    positionQueue.Push(new Position(currentCol, currentRow + 1, steps + 1));
                }
            }
        }

        public static Position FindStartPosition(string[,] maze)
        {
            int startingXPos = 0;
            int startingYPos = 0;
            for (int col = 0; col < maze.GetLength(0); col++)
            {
                for (int row = 0; row < maze.GetLength(1); row++)
                {
                    if (maze[col, row] == "*")
                    {
                        startingXPos = row;
                        startingYPos = col;
                        return new Position(startingYPos, startingXPos, 0);
                    }
                }
            }

            throw new ArgumentException("The maze does not have a starting position");
        }

        public static string[,] CopyArray(string[,] arrayToCopy)
        {
            string[,] result = new string[arrayToCopy.GetLength(0), arrayToCopy.GetLength(1)];
            for (int col = 0; col < result.GetLength(0); col++)
            {
                for (int row = 0; row < result.GetLength(1); row++)
                {
                    result[col, row] = arrayToCopy[col, row];
                }
            }

            return result;
        }

        public static string ArrayToString(string[,] array)
        {
            StringBuilder sb = new StringBuilder();

            for (int col = 0; col < array.GetLength(0); col++)
            {
                for (int row = 0; row < array.GetLength(1); row++)
                {
                    sb.AppendFormat("{0} ", array[col, row]);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
