using System;

class BinarySearch
{
    static void Main()
    {
        int[] sortedArray = { 1, 5, 9, 12, 16, 49, 132, 189, 215, 365, 366, 378, 398, 405, 423, 456, 478, 489, 499, 512, 567, 589, 599 };
        int maxIndex = sortedArray.Length;
        int minIndex = 0;
        int midPoint;
        int searchedValue = int.Parse(Console.ReadLine());
        bool found = false;

        while (maxIndex >= minIndex)
        {
            midPoint = (minIndex + maxIndex) / 2;

            if (sortedArray[midPoint] < searchedValue)
            {
                minIndex = midPoint + 1;
            }
            else if (sortedArray[midPoint] > searchedValue)
            {
                maxIndex = midPoint - 1;
            }
            else if (sortedArray[midPoint] == searchedValue)
            {
                Console.WriteLine("Value found at position {0}", midPoint);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("The value is not present in the array");
        }
    }
}