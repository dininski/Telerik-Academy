using System;

class MaximumSumInArray
{
    static void Main()
    {
        int[] arrayToCheck = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int sum = 0;
        int maxSum = 0;
        int start = 0;
        int end = 0;

        for (int i = 0; i < arrayToCheck.Length; i++)
        {
            sum = 0;
            for (int j = i; j < arrayToCheck.Length; j++)
            {
                sum += arrayToCheck[j];
                
                if (sum > maxSum)
                {
                    start = i;
                    end = j;
                    maxSum = sum;
                }
            }
        }

        Console.WriteLine("The maximum available sum is: {0}", maxSum);
        for (int k = start; k < end+1; k++)
        {
            Console.WriteLine(arrayToCheck[k]);
        }
    }
}