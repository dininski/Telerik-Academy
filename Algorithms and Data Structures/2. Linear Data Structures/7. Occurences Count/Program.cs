namespace OccurencesCount
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            int[] occurences = new int[1001];

            for (int i = 0; i < testArray.Length; i++)
            {
                occurences[testArray[i]]++;
            }

            for (int i = 0; i < occurences.Length; i++)
            {
                if (occurences[i] != 0)
                {
                    Console.WriteLine("Number {0} occurs {1} times", i, occurences[i]);
                }
            }
        }
    }
}
