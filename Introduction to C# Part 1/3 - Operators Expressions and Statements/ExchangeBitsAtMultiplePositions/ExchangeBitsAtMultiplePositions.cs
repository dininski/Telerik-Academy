using System;


namespace ExchangeBitsAtMultiplePositions
{
    class ExchangeBitsAtMultiplePositions
    {
        static void Main()
        {
            int[] position1= { 3, 4, 5 };
            int[] position2 = { 24, 25, 26 };
            int number;
            int temp1,temp2;
            Console.WriteLine("Please enter an integer");
            number = int.Parse(Console.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                temp1 = 1 & (number >> position2[i]);
                temp2 = 1 & (number >> position1[i]);
                if (temp1 == 1)
                {
                    number = number | (1 << position1[i]);
                }
                else
                {
                    number = number & (~(1 << position1[i]));
                }

                if (temp2 == 1)
                {
                    number = number | (1 << position2[i]);
                }
                else
                {
                    number = number & (~(1 << position2[i]));
                }
            }
            Console.WriteLine(number);
        }
    }
}
