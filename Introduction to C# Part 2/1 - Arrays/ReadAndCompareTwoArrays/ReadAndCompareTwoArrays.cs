using System;

class ReadAndCompareTwoArrays
{
    static void Main(string[] args)
    {
        int firstArrayLength = int.Parse(Console.ReadLine());
        int secondArrayLength = int.Parse(Console.ReadLine());
        int[] firstArray = new int[firstArrayLength];
        int[] secondArray = new int[secondArrayLength];

        for (int i = 0; i < firstArrayLength; i++)
        {
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < secondArrayLength; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        if (secondArrayLength != firstArrayLength)
        {
            Console.WriteLine("Arrays are different lengths");
        }
        else
        {
            for (int i = 0; i < firstArrayLength; i++)
            {
                if (firstArray[i] == secondArray[i])
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Arrays are different, because element number {0} in first array is {1} and in the second one is {2}", i, firstArray[i], secondArray[i]);
                    return;
                }
            }
            Console.WriteLine("Arrays are the same length and contain the same elements");
        }
    }
}