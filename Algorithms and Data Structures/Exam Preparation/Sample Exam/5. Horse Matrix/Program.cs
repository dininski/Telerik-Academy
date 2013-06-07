using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main(string[] args)
    {
        int matrixSize = int.Parse(Console.ReadLine());

        string[,] matrix = new string[matrixSize, matrixSize];

        Position startPosition = new Position(0, 0);

        bool[,] visited = new bool[matrixSize, matrixSize];

        for (int col = 0; col < matrixSize; col++)
        {
            string rowDataString = Console.ReadLine();
            string[] rowData = rowDataString.Split(' ');
            for (int row = 0; row < matrixSize; row++)
            {
                matrix[col, row] = rowData[row];
                if (rowData[row] == "s")
                {
                    startPosition = new Position(col, row);
                    visited[col, row] = true;
                }
                if (rowData[row] != "-")
                {
                    visited[col, row] = true;
                }
            }
        }

        Queue<Position> positions = new Queue<Position>();
        positions.Enqueue(startPosition);

        int[] possibleCols = new int[] { 2, -2, 1, -1, 2, -2, 1, -1 };
        int[] possibleRows = new int[] { 1, 1, 2, 2, -1, -1, -2, -2 };

        while (positions.Count > 0)
        {
            Position current = positions.Dequeue();

            for (int i = 0; i < possibleRows.Length; i++)
            {
                var newCol = current.Col + possibleCols[i];
                var newRow = current.Row + possibleRows[i];

                if (newCol >= 0 && newCol < matrixSize
                    && newRow >= 0 && newRow < matrixSize)
                {
                    if (!visited[newCol, newRow])
                    {
                        visited[newCol, newRow] = true;
                        var newPosition = new Position(newCol, newRow, current.Hops + 1);
                        matrix[newCol, newRow] = newPosition.Hops.ToString();
                        positions.Enqueue(newPosition);
                    }

                    if (matrix[newCol, newRow] == "e")
                    {
                        Console.WriteLine(current.Hops + 1);
                        return;
                    }
                }
            }
        }

        Console.WriteLine("No");
    }

    public class Position
    {
        public Position(int col, int row)
            : this(col, row, 0)
        {
        }

        public Position(int col, int row, int hops)
        {
            this.Col = col;
            this.Row = row;
            this.Hops = hops;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Hops { get; set; }
    }
}