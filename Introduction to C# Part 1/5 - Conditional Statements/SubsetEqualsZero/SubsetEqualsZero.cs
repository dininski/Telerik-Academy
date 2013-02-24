using System;

class SubsetEqualsZero
{
    static void Main()
    {
        int[] valueSet = new int[5];
        int counter = 0;
        for (int i = 0; i < valueSet.Length; i++)
        {
            Console.WriteLine("Please enter value number {0}:", i + 1);
            valueSet[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 1; i < Math.Pow(2, valueSet.Length); i++)
        {
            int subsetSum = 0;
            for (int j = 0; j < valueSet.Length; j++)
            {
                subsetSum += ((i >> j) & 1) * valueSet[j];
            }
            if (subsetSum == 0)
            {
                counter++;
            }
        }
        Console.WriteLine("Total subsets that have sum of 0: {0}", counter);
    }
}

