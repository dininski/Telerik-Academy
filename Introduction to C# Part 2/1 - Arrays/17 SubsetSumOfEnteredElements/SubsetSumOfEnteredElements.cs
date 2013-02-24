using System;
using System.Collections.Generic;

class SubsetSumOfEnteredElements
{
    static void Main()
    {

        List<int> answer = new List<int>();
        Console.WriteLine("Please enter array length: ");
        int numberOfElements = int.Parse(Console.ReadLine());
        int[] arrayToCheck = new int[numberOfElements];
        Console.WriteLine("Please enter array elements:");
        for (int i = 0; i < numberOfElements; i++)
        {
            arrayToCheck[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Please enter the sum, that you are looking for: ");
        int sumToFind = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter the amount of elements that need to make the sum:");
        int sumElements = int.Parse(Console.ReadLine());
        int currentSumElements = 0;

        int currentSum = 0;
        int possibleCombinations = (int)(Math.Pow(2, arrayToCheck.Length) - 1);

        for (int i = 1; i < possibleCombinations; i++)
        {
            currentSumElements = 0;
            answer.Clear();
            currentSum = 0;
            for (int j = 0; j < arrayToCheck.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    currentSumElements++;
                    answer.Add(arrayToCheck[j]);
                    currentSum += arrayToCheck[j];
                }
            }

            if (currentSum == sumToFind && sumElements == currentSumElements)
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
