using System;
using System.Collections.Generic;

class MinimumRemovedToSortArray
{
    static bool checkIfIncreasing(List<int> someSet)
    {
        for (int i = 0; i < someSet.Count - 1; i++)
        {
            if (someSet[i + 1] < someSet[i])
            {
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        int[] setOfElements = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        int allPossibleCombinations = (int)(Math.Pow(2, setOfElements.Length)) - 1;
        List<int> answer = new List<int>();

        for (int i = 1; i < allPossibleCombinations; i++)
        {
            List<int> subSet = new List<int>();
            int lengthOfCurrentSubset = 0;
            for (int j = 0; j < setOfElements.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    subSet.Add(setOfElements[j]);
                    lengthOfCurrentSubset++;
                }
            }

            if (checkIfIncreasing(subSet) && answer.Count < lengthOfCurrentSubset)
            {
                answer = subSet;
            }
        }

        Console.WriteLine("The subset left after removing the least amount of elements");
        foreach (int number in answer)
        {
            Console.Write(number + " ");
        }
    }
}
