using System;

namespace ExtraAssignmentSwapBits
{
    class ExtraAssignmentSwapBits
    {
        static void Main()
        {
            int temp1, temp2;
            Console.WriteLine("Please enter starting position of first bits:");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter starting position of swapped bits:");
            int q = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Please enter step:");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter an integer:");
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < k-1; i++)
            {
                temp1 = 1 & (number >> p);
                temp2 = 1 & (number >> q);
                number = (temp1 == 1) ? number | (1 << q) : number & (~(1 << q));
                number = (temp2 == 1) ? number | (1 << p) : number & (~(1 << p));
                p++;
                q++;
            }
            Console.WriteLine(number);
        }
    }
}
