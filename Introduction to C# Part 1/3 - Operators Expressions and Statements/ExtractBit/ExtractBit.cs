using System;

namespace ExtractBit
{
    class ExtractBit
    {
        static void Main()
        {
            int position;
            int number;
            int bitAtPosition;
            Console.WriteLine("Please enter number:");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter position of bit to extract:");
            position = int.Parse(Console.ReadLine());
            bitAtPosition = 1 & (number >> position);
            Console.WriteLine(bitAtPosition);
        }
    }
}
