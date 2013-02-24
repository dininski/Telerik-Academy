using System;

namespace Exercise_3
{
    class RectangleArea
    {
        static void Main()
        {
            int height;
            int width;
            Console.WriteLine("Please enter height:");
            height = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter width:");
            width = int.Parse(Console.ReadLine());
            int area;
            area = height * width;
            Console.WriteLine(area);
        }
    }
}
