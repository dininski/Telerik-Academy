using System;

class SelectionSort
{
    static void Main(string[] args)
    {
        int[] arrayToSort = { 8, 5, 2, 6, 1, 3, 9, 7, 4 };

        int smallestElement;

        for (int i = 0; i < arrayToSort.Length; i++)
        {
            smallestElement = arrayToSort[i];
            for (int n = i + 1; n < arrayToSort.Length; n++)
            {
                if (arrayToSort[n] < smallestElement)
                {
                    smallestElement += arrayToSort[n];
                    arrayToSort[n] = smallestElement - arrayToSort[n];
                    smallestElement = smallestElement - arrayToSort[n];
                }
            }

            if (smallestElement != arrayToSort[i])
            {
                arrayToSort[i] = smallestElement;
            }
        }

        foreach (int num in arrayToSort)
        {
            Console.WriteLine(num);
        }
    }
}