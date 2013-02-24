using System;

namespace InCircleOutOfRectangle
{
    class InCircleOutOfRectangle
    {
        static void Main()
        {
            double x;
            double y;
            Console.WriteLine("Please enter x:");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter y:");
            y = double.Parse(Console.ReadLine());

            if ((Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2)) <= 9)
            {
                Console.Write("The point is within the circle ");
                if ((x < -1 || x > 4) || (y < -1 || y > 1))
                {
                    Console.WriteLine("and out of the rectangle");
                }
                else
                {
                    Console.WriteLine("and inside the rectangle");
                }
            }
            else 
            {
                Console.WriteLine("The point is not in the circle");
            }

        }
    }
}
