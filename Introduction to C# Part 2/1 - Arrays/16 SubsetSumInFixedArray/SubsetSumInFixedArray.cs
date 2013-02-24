using System;
using System.Collections.Generic;

class SubsetSumInFixedArray
{
    static void Main()
    {
        int[] arrayToCheck = { 2, 1, 2, 4, 3, 5, 2, 6 };
        List<int> answer = new List<int>();
        int sumToFind = 14;
        int currentSum = 0;
        int possibleCombinations = (int)(Math.Pow(2, arrayToCheck.Length) - 1);

        for (int i = 1; i < possibleCombinations; i++)
        {
            answer.Clear();
            currentSum = 0;
            for (int j = 0; j < arrayToCheck.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    answer.Add(arrayToCheck[j]);
                    currentSum += arrayToCheck[j];
                }
            }

            if (currentSum == sumToFind)
            {
                Console.WriteLine("Sum found and can be made with the following elements: ");
                foreach (int number in answer)
                {
                    Console.Write("{0} ", number);
                }
                break;
            }
            if (i == possibleCombinations - 1 && currentSum != sumToFind)
            {
                Console.WriteLine("No sum of {0} can be made with the array elements", sumToFind);
            }
        }
    }
}
