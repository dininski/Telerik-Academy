using System;
using System.Collections.Generic;

class MaximumSeqIncreasing
{
    static void Main(string[] args)
    {
        int[] testArray = { 3, 2, 3, 4, 2, 2, 4 };
        List<int> maximumSeqArray = new List<int>();
        int start = 0;
        int length = 1;
        int bestStart = 0;
        int bestLength = 1;

        for (int i = 0; i < testArray.Length - 1; i++)
        {
            if (testArray[i] < testArray[i + 1])
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
                start = i + 1;
            }
        }

        for (int n = bestStart; n < bestStart + bestLength; n++)
        {
            maximumSeqArray.Add(testArray[n]);
            Console.Write("{0}, ", testArray[n]);
        }
    }
}
