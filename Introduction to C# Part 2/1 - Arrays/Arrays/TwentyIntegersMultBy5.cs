using System;

class TwentyIntegersMultBy5
{
    static void Main(string[] args)
    {
        int[] values = new int[20];

        for (int i = 0; i < 20; i++)
        {
            values[i] = i * 5;
        }

        foreach (int number in values)
        {
            Console.WriteLine(number);
        }
    }
}