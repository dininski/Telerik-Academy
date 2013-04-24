namespace LoopRefactoring
{
    using System;

    public class LoopProgram
    {
        public static void Main(string[] args)
        {
            int[] valuesToSearch = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int expectedValue = 11;
            for (int i = 0; i < valuesToSearch.Length; i++)
            {
                // checks every 10th value if is equal to expectedValue
                if (i % 10 == 0)
                {
                    Console.WriteLine(valuesToSearch[i]);
                    if (valuesToSearch[i] == expectedValue)
                    {
                        Console.WriteLine("Value Found");
                    }
                }
            }
        }
    }
}
