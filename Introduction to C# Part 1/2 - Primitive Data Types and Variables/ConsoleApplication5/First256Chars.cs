using System;

namespace ConsoleApplication5
{
    class First256Chars
    {
        static void Main()
        {
            char character;

            for (int counter = 0; counter < 256; counter++)
            {
                character = (char)counter;
                Console.WriteLine("Char: {0}, position: {1}",character,counter);
            }
        }
    }
}
