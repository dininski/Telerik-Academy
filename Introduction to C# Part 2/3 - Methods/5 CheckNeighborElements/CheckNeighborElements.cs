using System;

class CheckNeighborElements
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

    static void Main(string[] args)
    {
        int[] someInts = { 4, 2, 8, 3, 6, 9, 4, 5, 7, 8, 5, 2, 1, 6, 15 };
        Console.WriteLine("An array with some random int values:");
        foreach (var number in someInts)
        {
            Console.Write("{0} ", number);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Please enter position to check:");
        int position = int.Parse(Console.ReadLine());
        if (IsBiggerThanNeighbors(position, someInts))
        {
            Console.WriteLine("The number {0} which is on position {1} is bigger than it's neighbours.", someInts[position], position);
        }
        else
        {
            Console.WriteLine("The number {0} which is on position {1} is not bigger than it's neighbours.", someInts[position], position);

        }
    }
}