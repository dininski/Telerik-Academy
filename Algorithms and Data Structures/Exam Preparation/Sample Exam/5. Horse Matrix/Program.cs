using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: implement with tree
namespace _5.Horse_Matrix
{
    class Program
    {
        public static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            
            char[,] matrix = new char[matrixSize, matrixSize];
            Position startPosition = new Position();

            for (int col = 0; col < matrixSize; col++)
            {
                string rowData = Console.ReadLine();
                rowData = rowData.Replace(" ", string.Empty);
                var rowChars = rowData.ToCharArray();
                for (int row = 0; row < matrixSize; row++)
                {
                    matrix[col, row] = rowChars[row];

                    if (rowChars[row] == 's')
                    {
                        startPosition = new Position(col, row);
                    }
                }
            }

            Stack<Position> positions = new Stack<Position>();
            positions.Push(startPosition);
            int fastestPath = int.MaxValue;

            int[,] possibleMoves = new int[,] { { 1, 2 }, { 1, -2 }, { 2, 1 }, { 2, -1 }, { -1, 2 }, { -1, -2 }, { -2, 1 }, { -2, -1 } };

            while (positions.Count != 0)
            {
                Position current = positions.Pop();
                if (matrix[current.Col, current.Row] == 'e')
                {
                    if (current.Hops < fastestPath)
                    {
                        fastestPath = current.Hops;
                    }
                    continue;
                }

                for (int i = 0; i < possibleMoves.GetLength(0); i++)
                {
                    var newCol = current.Col + possibleMoves[i, 0];
                    var newRow = current.Row + possibleMoves[i, 1];
                    if (newCol >= 0 && newCol < matrixSize
                        && newRow >= 0 && newRow < matrixSize
                        && matrix[newCol, newRow] != 'x')
                    {
                        var newPosition = new Position(newCol, newRow, current.Hops + 1, current.Visited);
                        if (!current.IsVisited(newPosition))
                        {
                            newPosition.Visit(newPosition);
                            positions.Push(newPosition);
                        }
                    }
                }
            }

            if (fastestPath != int.MaxValue)
            {
                Console.WriteLine(fastestPath);
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public class Position
        {
            public Position()
            {
            }

            public Position(int col, int row)
                : this(col, row, 0)
            {
            }

            public Position(int col, int row, int hops)
                : this(col, row, hops, new HashSet<Position>())
            {
            }

            public Position(int col, int row, int hops, HashSet<Position> previouslyVisited)
            {
                this.Col = col;
                this.Row = row;
                this.Hops = hops;
                this.Visited = new HashSet<Position>(previouslyVisited);
            }

            public bool IsVisited(Position pos)
            {
                return this.Visited.Where(x => x.Row.Equals(pos.Row) && x.Col.Equals(pos.Col)).Count() != 0;
            }

            public void Visit(Position pos)
            {
                this.Visited.Add(pos);
            }

            public HashSet<Position> Visited;
            public int Row { get; set; }
            public int Col { get; set; }
            public int Hops { get; set; }
        }
    }
}