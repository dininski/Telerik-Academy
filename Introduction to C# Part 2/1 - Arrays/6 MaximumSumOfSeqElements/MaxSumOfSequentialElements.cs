using System;
using System.Collections.Generic;

class MaxSumOfSequentialElements
{
    static void Main(string[] args)
    {
        int[] arrayToBeChecked;
        int arrayLength;
        int subsetLength;
        int maxSum = 0;
        int sum = 0;

        Console.WriteLine("Please enter array length:");
        arrayLength = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter subset length");
        subsetLength = int.Parse(Console.ReadLine());
        arrayToBeChecked = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            Console.WriteLine("Please enter element {0}:", i);
            arrayToBeChecked[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < arrayLength; i++)
        {
            if (i < subsetLength)
            {
                sum += arrayToBeChecked[i];
                maxSum = sum;
            }
            else
            {
                sum = sum - arrayToBeChecked[i-subsetLength] + arrayToBeChecked[i];
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
        }

        Console.WriteLine("Maximum sum of the sequential elements is: {0}", maxSum);
    }
}