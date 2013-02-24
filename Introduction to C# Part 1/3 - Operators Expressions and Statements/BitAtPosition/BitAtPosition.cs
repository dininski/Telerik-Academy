using System;

namespace BitAtPosition
{
    class BitAtPosition
    {
        static void Main()
        {
            int position;
            int number;
            Console.WriteLine("Please enter number:");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter position to check:");
            position = int.Parse(Console.ReadLine());
            bool isOne;
            isOne = (1 & (number >> position)) == 1 ? true:false;
            if (isOne)
            {
                Console.WriteLine("The bit at position {0} is 1", position);
            }
            else
            {
                Console.WriteLine("The bit at position {0} is 0", position);
            }
            }
        }
    }
