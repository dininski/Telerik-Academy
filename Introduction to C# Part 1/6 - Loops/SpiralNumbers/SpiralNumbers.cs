using System;
using System.Collections.Generic;

class SpiralNumbers
{
    static int currentNum = 0;

    public static int getNextNumber() {
        currentNum++;
        return currentNum;
    }

    static void Main()
    {
        Console.WriteLine("Please enter number:");
        int userInput = int.Parse(Console.ReadLine());
        int[,] result = new int[userInput, userInput];
        for (int fullCircles = 0; fullCircles <= userInput/2; fullCircles++)
        {
            for (int col = fullCircles; col < userInput - fullCircles; col++)
            {
                result[fullCircles, col] = getNextNumber();
            }
            for (int row = 1 + fullCircles; row < userInput-fullCircles; row++)
            {
                result[row, userInput-fullCircles-1] = getNextNumber();
            }
            for (int col = userInput-fullCircles-2; col > fullCircles-1; col--)
            {
                result[userInput-fullCircles-1,col]=getNextNumber();
            }
            for (int row = userInput - fullCircles - 2; row > fullCircles; row--)
            {
                result[row,fullCircles]=getNextNumber();
            }
        }
        int lineBreak = 0;
        foreach (int number in result)
        {
            lineBreak++;
            Console.Write("\t" + number);
            if (lineBreak % userInput == 0)
            {
                Console.WriteLine();
            }
        }
    }
}

