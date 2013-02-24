using System;

class SequenceOfGivenSum
{
    static void Main(string[] args)
    {
        int[] arrayToCheck = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int sum = int.Parse(Console.ReadLine());
        int currentSum;
        Boolean answerFound = false;

        for (int i = 0; i < arrayToCheck.Length; i++)
        {
            if (!answerFound)
            {
                currentSum = 0;
                for (int n = i; n < arrayToCheck.Length; n++)
                {
                    currentSum += arrayToCheck[n];
                    if (currentSum == sum)
                    {
                        answerFound = true;
                        Console.WriteLine("Sum found!");
                        for (int k = i; k < n + 1; k++)
                        {
                            Console.Write("{0} ", arrayToCheck[k]);
                        }
                    }
                }
            }
        }
    }
}

