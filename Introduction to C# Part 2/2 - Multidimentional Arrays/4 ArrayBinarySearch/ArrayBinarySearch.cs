using System;

class BinSearchLargerstNumber
{
    static void Main()
    {
        Console.WriteLine("How many numbers you want to enter?");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        Console.WriteLine("Start entering numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Please enter K:");
        int k = int.Parse(Console.ReadLine());


        Array.Sort(numbers);
        int index = Array.BinarySearch(numbers, k);
        Console.WriteLine(index);
        if (index >= 0)
        {
            Console.WriteLine("The largest number in the array which is ≤ K is {0}", numbers[index]);
        }
        else
        {
            Console.WriteLine("The largest number in the array which is ≤ K is {0}", numbers[-index - 2]);
        }
    }
}