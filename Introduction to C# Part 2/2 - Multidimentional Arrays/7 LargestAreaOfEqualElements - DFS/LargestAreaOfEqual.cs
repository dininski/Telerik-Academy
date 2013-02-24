using System;
using System.Collections.Generic;

class DFS
{
    public static int DFSearch(int[,] someArray)
    {
        int current;
        int max = 1;
        for (int row = 0; row < someArray.GetLength(0); row++)
        {
            for (int col = 0; col < someArray.GetLength(1); col++)
            {
                current = checkAdjacent(row, col, someArray);
                max = current > max ? current : max;
            }
        }
        return max;
    }

    public static bool CanStep(int x, int y, int[,] ourArray)
    {
        return x >= 0 && y >= 0 && x < ourArray.GetLength(0) && y < ourArray.GetLength(1);
    }

    public static int checkAdjacent(int x, int y, int[,] someArray)
    {
        int counter = 1;
        int value = someArray[x, y];
        someArray[x, y] = int.MinValue;
        if (value == int.MinValue)
        {
            return 0;
        }
        if (CanStep(x, y + 1, someArray) && value == someArray[x, y + 1])
        {
            counter += checkAdjacent(x, y + 1, someArray);
        }
        if (CanStep(x + 1, y, someArray) && value == someArray[x + 1, y])
        {
            counter += checkAdjacent(x + 1, y, someArray);
        }
        if (CanStep(x, y - 1, someArray) && value == someArray[x, y - 1])
        {
            counter += checkAdjacent(x, y - 1, someArray);
        }
        if (CanStep(x - 1, y, someArray) && value == someArray[x - 1, y])
        {
            counter += checkAdjacent(x - 1, y, someArray);
        }
        someArray[x, y] = int.MinValue;
        return counter;
    }

    public static void PrintArray(int[,] arrayToPrint)
    {
        for (int i = 0; i < arrayToPrint.GetLength(0); i++)
        {
            for (int j = 0; j < arrayToPrint.GetLength(1); j++)
            {
                Console.Write("{0} ", arrayToPrint[i, j]);
            }

            Console.WriteLine();
        }

    }

    static void Main(string[] args)
    {

        int[,] arrayToSearch = {
                                   {1,3,2,2,2,4},
                                   {3,3,3,2,4,4},
                                   {4,3,1,2,3,3},
                                   {4,3,1,3,3,3},
                                   {4,3,3,3,1,1}
                               };

        PrintArray(arrayToSearch);
        Console.WriteLine();
        Console.WriteLine("The largest area of connected equal elements is: {0}",DFSearch(arrayToSearch));
    }
}
