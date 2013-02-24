using System;

class FirstElementBiggerThanNeighbors
{
    public static bool IsBiggerThanNeighbors(int number, int[] arrayOfInts)
    {
        if (number == 0 && arrayOfInts.Length > 1)
        {
            return arrayOfInts[number] > arrayOfInts[1];
        }
        else if (number == arrayOfInts.Length - 1 && arrayOfInts.Length > 1)
        {
            return arrayOfInts[number] > arrayOfInts[arrayOfInts.Length - 2];
        }
        else
        {
            return (arrayOfInts[number - 1] < arrayOfInts[number] && arrayOfInts[number] > arrayOfInts[number + 1]);
        }
    }

    public static int FirstBigger(int[] arrayOfInts)
    {
        int currentPosition = 0;
        while (currentPosition < arrayOfInts.Length)
        {
            if (IsBiggerThanNeighbors(currentPosition, arrayOfInts))
            {
                return currentPosition;
            }
            currentPosition++;
        }
        return -1;
    }

    public static int[] CreateArray(int length)
    {
        int[] arrayOfNums = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine("Please enter element {0}:", i);
            arrayOfNums[i] = int.Parse(Console.ReadLine());
        }

        return arrayOfNums;
    }

    public static void PrintArray(int[] someArray)
    {
        foreach (var item in someArray)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter array length:");
        int arrayLength = int.Parse(Console.ReadLine());
        int[] userValues = CreateArray(arrayLength);
        Console.WriteLine("You entered the following array: ");
        PrintArray(userValues);
        Console.WriteLine();
        int position = FirstBigger(userValues);
        if (position != -1)
        {
            Console.WriteLine("The first elements which is bigger than it's neighbours is at position: {0}", position);
        }
        else
        {
            Console.WriteLine("There is no element, bigger than it's neighbours");
        }
    }
}