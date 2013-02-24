using System;

class Sorting
{
    public static void PrintArray(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine();
    }

    public static int MaxElementAtPos(int[] numbers, int startPos)
    {
        int maxElement = int.MinValue;
        int positionOfMax = 0;
        for (int i = startPos; i < numbers.Length; i++)
        {
            if (maxElement < numbers[i])
            {
                maxElement = numbers[i];
                positionOfMax = i;
            }
        }
        return positionOfMax;
    }

    public static void SortArray(int[] numbers)
    {
        for (int currentElement = 0; currentElement < numbers.Length; currentElement++)
        {
            int elementToMove = MaxElementAtPos(numbers, currentElement);
            SwapElements(numbers, currentElement, elementToMove);
        }
    }

    public static void SwapElements(int[] numbers, int currentEl, int toMove)
    {
        int holder = numbers[currentEl];
        numbers[currentEl] = numbers[toMove];
        numbers[toMove] = holder;
    }

    static void Main(string[] args)
    {
        int[] testNumbers = { 1, 22, 3, 4, 15, 61, 7, 8 };
        Console.WriteLine("Unsorted array:");
        PrintArray(testNumbers);
        Console.WriteLine("Sorted in descending order:");
        SortArray(testNumbers);
        PrintArray(testNumbers);
        Console.WriteLine("Sorted in ascending order by reversing the array with Array.Reverse() :");
        Array.Reverse(testNumbers);
        PrintArray(testNumbers);
    }
}
