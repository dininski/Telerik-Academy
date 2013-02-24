using System;

class QuadraticEquation
{
    static void Main()
    {
        int a;
        int b;
        int c;
        double x1;
        double x2;
        Console.WriteLine("For a*x^2 + b*x + c = 0 , please enter a: ");
        int.TryParse(Console.ReadLine(), out a);
        Console.WriteLine("b:");
        int.TryParse(Console.ReadLine(), out b);
        Console.WriteLine("c:");
        int.TryParse(Console.ReadLine(), out c);

        x1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / 2 * a;
        x2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / 2 * a;
        if (x1 == x2)
        {
            Console.WriteLine("One real root, x1 = {0}", x1);
        }
        else if (double.IsNaN(x1))
        {
            Console.WriteLine("0 roots");
        }
        else
        {
            Console.WriteLine("Two real roots, x1 = {0} and x2 = {1}", x1, x2);
        }

    }
}
