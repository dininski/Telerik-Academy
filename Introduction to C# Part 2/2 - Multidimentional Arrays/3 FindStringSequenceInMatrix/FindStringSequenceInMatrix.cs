using System;

class StringSequence
{
    static void Main(string[] args)
    {
        int bestSequence = 1;
        int currentSequence = 1;
        String[,] stringArray = { 
                                   {"ha", "fifi", "xxx", "hi"},
                                   {"fo", "ha", "hi", "xx"},
                                   {"xxx", "ho", "ha", "xx"},
                               };

        //String[,] stringArray = {
        //                            {"s", "qq", "s"},
        //                            {"pp", "pp", "s"},
        //                            {"pp", "qq", "s"}
        //                        };

        //check horizontal
        for (int col = 0; col < stringArray.GetLength(0); col++)
        {
            currentSequence = 1;
            for (int row = 0; row < stringArray.GetLength(1) - 1; row++)
            {
                if (stringArray[col, row] == stringArray[col, row + 1])
                {
                    currentSequence++;
                    if (currentSequence > bestSequence)
                    {
                        bestSequence = currentSequence;
                    }
                }
                else
                {
                    currentSequence = 1;
                }
            }
        }
        
        //check vertical
        for (int row = 0; row < stringArray.GetLength(1); row++)
        {
            currentSequence = 1;
            for (int col = 0; col < stringArray.GetLength(0)-1; col++)
            {
                if (stringArray[col, row] == stringArray[col+1, row])
                {
                    currentSequence++;
                    if (currentSequence > bestSequence)
                    {
                        bestSequence = currentSequence;
                    }
                }
                else
                {
                    currentSequence = 1;
                }
            }
            
        }


        //check first diagonal
        for (int i = 0; i < stringArray.GetLength(0); i++)
        {
            for (int j = 0; j < stringArray.GetLength(1); j++)
            {
                currentSequence = 1;
                for (int currentCol = i, currentRow = j; currentCol < stringArray.GetLength(1) - 1 && currentRow < stringArray.GetLength(0) - 1; currentCol++, currentRow++)
                {
                    if (stringArray[currentRow, currentCol] == stringArray[currentRow + 1, currentCol + 1])
                    {
                        currentSequence++;
                        if (currentSequence > bestSequence)
                        {
                            bestSequence = currentSequence;
                        }
                    }
                    else
                    {
                        currentSequence = 1;
                    }
        
                }
            }
        }
        
        //check reverse diagonal
        for (int i = stringArray.GetLength(0) - 1; i > 0; i--)
        {
            for (int j = 0; j < stringArray.GetLength(1); j++)
            {
                currentSequence = 1;
                for (int currentCol = i, currentRow = j; currentRow < stringArray.GetLength(0) - 2 && currentCol > 0; currentCol--, currentRow++)
                {
                    if (stringArray[currentCol, currentRow] == stringArray[currentCol - 1, currentRow + 1])
                    {
                        currentSequence++;
                        if (currentSequence > bestSequence)
                        {
                            bestSequence = currentSequence;
                        }
                    }
                    else
                    {
                        currentSequence = 1;
                    }
                }

            }
        }
        Console.WriteLine(bestSequence);
    }
}