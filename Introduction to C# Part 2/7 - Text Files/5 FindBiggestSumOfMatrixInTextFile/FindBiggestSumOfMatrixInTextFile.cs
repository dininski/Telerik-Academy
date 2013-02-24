using System;
using System.IO;

class FindBiggestSumOfMatrixInTextFile
{
    public static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0} ",matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    public static int BestSum(int[,] matrix, int subMatrixSize = 2)
    {
        int currentSum;
        int bestSum = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0) - subMatrixSize + 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - subMatrixSize + 1; j++)
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
        return bestSum;
    }

    static void Main(string[] args)
    {
        string path = "../../matrixFile.txt";
        StreamReader reader = new StreamReader(path);
        int[,] matrix;
        using (reader)
        {
            int sizeOfMatrix = int.Parse(reader.ReadLine());
            matrix = new int[sizeOfMatrix,sizeOfMatrix];
            int currentRow = 0;
            while (!reader.EndOfStream)
            {
                string[] rowElementsAsString = new string[sizeOfMatrix];
                rowElementsAsString = reader.ReadLine().Split(' ');
                for (int i = 0; i < rowElementsAsString.Length; i++)
                {
                    matrix[currentRow, i] = int.Parse(rowElementsAsString[i]);
                }
                currentRow++;
            }
        }

        PrintMatrix(matrix);
        Console.WriteLine("The best sum is {0}", BestSum(matrix));
    }
}
