using System;

namespace Exercise7
{
    class Circle
    {
        static void Main()
        {
            int x;
            int y;
            Console.WriteLine("Please enter x:");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter y:");
            y = int.Parse(Console.ReadLine());
            if (x * x + y * y <= 25)
            {
                Console.WriteLine("The point is in the circle");
            }
            else
            {
                Console.WriteLine("The point is outside the circle");
            }
        }
    }
}
