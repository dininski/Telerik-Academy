using System;
using System.Collections.Generic;
using System.Linq;

class MostFreqNumber
{
    static void Main(string[] args)
    {
        int[] arrayToCheck = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        Dictionary<int, int> occurences = new Dictionary<int, int>();
        for (int i = 0; i < arrayToCheck.Length; i++)
        {
            if (occurences.ContainsKey(arrayToCheck[i]))
            {
                occurences[arrayToCheck[i]]++;
            }
            else
            {
                occurences.Add(arrayToCheck[i], 1);
            }
        }

        int maxKey = occurences.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        int maxValue = occurences.Aggregate((l,r) => l.Value > r.Value ? l : r).Value;

        Console.WriteLine("Number with maximum occurences: {0} and number of occurences: {1}", maxKey, maxValue);
    }
}