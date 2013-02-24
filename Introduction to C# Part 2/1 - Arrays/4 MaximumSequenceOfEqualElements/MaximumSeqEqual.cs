using System;
using System.Collections.Generic;

class MaximumSeqEqual
{
    static void Main(string[] args)
    {
        int[] testArray = {2, 1, 1, 2, 3, 3, 2, 2, 2, 2, 1};
        List<int> maximumSeqArray = new List<int>();
        int start=0;
        int length=1;
        int bestStart=0;
        int bestLength = 1;

        for (int i = 0; i < testArray.Length-1; i++)
        {
            if (testArray[i] == testArray[i + 1])
            {
                length++;

                if (length > bestLength)
                {
                    bestLength = length;
                    bestStart = start;
                }
            }
            else
            {
                length = 1;
                start = i+1;
            }
        }

        for (int n = bestStart; n < bestStart + bestLength; n++)
        {
            maximumSeqArray.Add(testArray[n]);
            Console.WriteLine("elements: {0}", testArray[n]);
        }

    }
}