using System;

class HowManyTimesNumInArray
{
    static int NumOccurences(int num, int[] numArray)
    {
        int occurences = 0;
        foreach (var item in numArray)
        {
            if (num == item)
            {
                occurences++;
            }
        }
        return occurences;
    }

    static void Main(string[] args)
    {
        Console.Write("Please enter number:");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Please enter array length:");
        int arrLength = int.Parse(Console.ReadLine());
        int[] numArray = new int[arrLength];
        for (int i = 0; i < arrLength; i++)
        {
            Console.Write("Please enter {0} element: ", i);
            numArray[i] = int.Parse(Console.ReadLine());
        }

        int occurences = NumOccurences(number, numArray);

        Console.WriteLine("The number {0} appears {1} times in the array", number, occurences);
    }
}