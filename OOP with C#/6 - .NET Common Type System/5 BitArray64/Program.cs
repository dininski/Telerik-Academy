using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        BitArray64 bitArray = new BitArray64();
        for (int i = 0; i < 64; i++)
        {
            bitArray[i] = 0;
        }
        bitArray[2] = 1;
        bitArray[36] = 1;

        Console.WriteLine("Showing the array...");
        Console.WriteLine("Using foreach:");
        foreach (var num in bitArray)
        {
            Console.Write(num);
        }
        Console.WriteLine();

        IEnumerator enumerator = bitArray.GetEnumerator();

        Console.WriteLine("Using enumerator:");
        while (enumerator.MoveNext())
        {
            Console.Write(enumerator.Current);
        }
        Console.WriteLine();
        Console.WriteLine("Value of the ulong variable in the BitArray64: {0}", bitArray.ToString());
    }
}