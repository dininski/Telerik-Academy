using System;


namespace QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main()
        {
            int a;
            int b;
            int c;
            double x1;
            double x2;
            Console.WriteLine("For the quadratic equation a*x^2+b*x+c=0, please enter a:");
            int.TryParse(Console.ReadLine(), out a);
            Console.WriteLine("Enter b:");
            int.TryParse(Console.ReadLine(), out b);
            Console.WriteLine("Enter c:");
            int.TryParse(Console.ReadLine(), out c);
            x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / 2 * a;
            x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / 2 * a;
            Console.WriteLine("x1 is {0} and x2 is {1}", x1, x2);
        }
    }
}
