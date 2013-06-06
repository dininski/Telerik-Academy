using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Horse_Matrix
{
    class Program
    {
        public static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            Position startPosition = new Position();
            Position endPosition = new Position();
            List<Position> possibleAnswers = new List<Position>();

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
                    if (rowChars[row] == 'e')
                    {
                        endPosition = new Position(col, row);
                    }
                }
            }

            Stack<Position> positions = new Stack<Position>();
            positions.Push(startPosition);
            while (positions.Count != 0)
            {
                Position current = positions.Pop();
                if (matrix[current.Col, current.Row] == 'e')
                {
                    possibleAnswers.Add(current);
                    continue;
                }

                if (current.Col + 2 < matrixSize && current.Row + 1 < matrixSize && matrix[current.Col + 2, current.Row + 1] != 'x')
                {
                    List<Position> vis = new List<Position>(current.Visited);
                    vis.Add(new Position(current.Col, current.Row));
                    positions.Push(new Position(current.Col + 2, current.Row + 1, current.Hops + 1, vis));
                }

                if (current.Col + 2 < matrixSize && current.Row - 1 >= 0 && matrix[current.Col + 2, current.Row - 1] != 'x')
                {
                    List<Position> vis = new List<Position>(current.Visited);
                    vis.Add(new Position(current.Col, current.Row));
                    positions.Push(new Position(current.Col + 2, current.Row - 1, current.Hops + 1, vis));
                }

                if (current.Col + 1 < matrixSize && current.Row - 2 >= 0 && matrix[current.Col + 1, current.Row - 2] != 'x')
                {
                    List<Position> vis = new List<Position>(current.Visited);
                    vis.Add(new Position(current.Col, current.Row));
                    positions.Push(new Position(current.Col + 1, current.Row - 2, current.Hops + 1, vis));
                }

                if (current.Col + 1 < matrixSize && current.Row + 2 < matrixSize && matrix[current.Col + 1, current.Row + 2] != 'x')
                {
                    List<Position> vis = new List<Position>(current.Visited);
                    vis.Add(new Position(current.Col, current.Row));
                    positions.Push(new Position(current.Col + 1, current.Row + 2, current.Hops + 1, vis));
                }

                if (current.Col - 2 >= 0 && current.Row + 1 < matrixSize && matrix[current.Col - 2, current.Row + 1] != 'x')
                {
                    List<Position> vis = new List<Position>(current.Visited);
                    vis.Add(new Position(current.Col, current.Row));
                    positions.Push(new Position(current.Col - 2, current.Row + 1, current.Hops + 1, vis));
                }

                if (current.Col - 2 >= 0 && current.Row - 1 < matrixSize && matrix[current.Col - 2, current.Row - 1] != 'x')
                {
                    List<Position> vis = new List<Position>(current.Visited);
                    vis.Add(new Position(current.Col, current.Row));
                    positions.Push(new Position(current.Col - 2, current.Row - 1, current.Hops + 1, vis));
                }

                if (current.Col - 1 >= 0 && current.Row + 2 < matrixSize && matrix[current.Col - 1, current.Row + 2] != 'x')
                {
                    List<Position> vis = new List<Position>(current.Visited);
                    vis.Add(new Position(current.Col, current.Row));
                    positions.Push(new Position(current.Col - 1, current.Row + 2, current.Hops + 1, vis));
                }

                if (current.Col - 1 >= 0 && current.Row - 2 >= 0 && matrix[current.Col - 1, current.Row - 2] != 'x')
                {
                    List<Position> vis = new List<Position>(current.Visited);
                    vis.Add(new Position(current.Col, current.Row));
                    positions.Push(new Position(current.Col - 1, current.Row - 2, current.Hops + 1, vis));
                }
            }

            for (int col = 0; col < matrixSize; col++)
            {
                for (int row = 0; row < matrixSize; row++)
                {
                    Console.Write("{0} ", matrix[col, row]);
                }
                Console.WriteLine();
            }

            foreach (var item in possibleAnswers)
            {
                Console.WriteLine(item.Hops);
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
                : this(col, row, hops, new List<Position>())
            {
            }

            public Position(int col, int row, int hops, List<Position> previouslyVisited)
            {
                this.Col = col;
                this.Row = row;
                this.Hops = hops;
                this.Visited = new List<Position>(previouslyVisited);
            }

            public bool Visit(Position pos)
            {
                if (!this.Visited.Contains(pos))
                {
                    this.Visited.Add(pos);
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public List<Position> Visited;
            public int Row { get; set; }
            public int Col { get; set; }
            public int Hops { get; set; }
        }
    }
}
