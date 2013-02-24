using System;

class MaxSum3x3
{
    static void printMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        int currentSum = 0;
        int bestSum = 0;
        int subMatrixSize = 3;
        Console.WriteLine("Please enter matrix dimensions: ");
        Console.Write("Rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Columns: ");
        int cols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.WriteLine("Element [{0}, {1}]:", i, j);
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < rows - subMatrixSize + 1; i++)
        {
            for (int j = 0; j < cols - subMatrixSize + 1; j++)
            {
                currentSum = 0;
                for (int subMatrixRows = i; subMatrixRows < i + subMatrixSize; subMatrixRows++)
                {
                    for (int subMatrixCols = j; subMatrixCols < j + subMatrixSize; subMatrixCols++)
                    {
                        currentSum += matrix[subMatrixRows, subMatrixCols];
                    }
                }
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                }
            }
        }
        printMatrix(matrix);
        Console.WriteLine("The biggest sum of a 3x3 square in the array is: {0}", bestSum);
    }
}