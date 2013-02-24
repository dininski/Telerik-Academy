using System;

class PrintAMartix
{
    static void verticalReverseFill(int[,] matrix)
    {
        int counter = 1;
        for (int col = 0; col < matrix.GetLength(0); col++)
        {

            if (col % 2 == 0)
            {
                for (int row = 0; row < matrix.GetLength(1); row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
            else
            {
                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
        }
        printMatrix(matrix);
    }

    static void verticalFill(int[,] matrix)
    {
        int counter = 1;
        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                matrix[row, col] = counter++;
            }
        }
        printMatrix(matrix);
    }

    static void diagonalFill(int[,] matrix)
    {
        int counter = 1;
        int n = matrix.GetLength(0);
        for (int start = 0; start < n; start++)
        {
            for (int i = n - start - 1, j = 0; i < n && j < n; i++, j++)
            {
                matrix[i,j] = counter++;
            }
        }

        for (int start = n-1; start > 0; start--)
        {
            for (int i = 0, j = n - start; i < n && j < n; i++, j++)
            {
                matrix[i, j] = counter++;
            }
        }

        printMatrix(matrix);
    }

    static void circleFill(int[,] matrix)
    {
        int counter = 1;

        for (int fullCircles = 0; fullCircles <= matrix.GetLength(0) / 2; fullCircles++)
        {
            for (int col = fullCircles; col < matrix.GetLength(0) - fullCircles; col++)
            {
                matrix[col, fullCircles] = counter++;
            }
            for (int row = 1 + fullCircles; row < matrix.GetLength(0) - fullCircles; row++)
            {
                matrix[matrix.GetLength(0) - fullCircles - 1,row] = counter++;
            }
            for (int col = matrix.GetLength(0) - fullCircles - 2; col > fullCircles - 1; col--)
            {
                matrix[col, matrix.GetLength(0) - fullCircles - 1] = counter++;
            }
            for (int row = matrix.GetLength(0) - fullCircles - 2; row > fullCircles; row--)
            {
                matrix[fullCircles, row] = counter++;
            }
        }
        printMatrix(matrix);
    }

    static void printMatrix(int[,] matrix)
    {
        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                Console.Write("{0, -3} ", matrix[col, row]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Please enter N: ");
        int n = int.Parse(Console.ReadLine());
        
        int[,] matrix = new int[n, n];
        
        verticalFill(matrix);
        verticalReverseFill(matrix);
        diagonalFill(matrix);
        circleFill(matrix);
    }
}