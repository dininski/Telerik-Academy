using System;



class SymbolOfProduct
{
    static void Main()
    {
        Console.WriteLine("Please enter first number: ");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter second number: ");
        double b = double.Parse(Console.ReadLine()); ;
        Console.WriteLine("Please enter third number: ");
        double c = double.Parse(Console.ReadLine()); ;

        int signCounter = 1;

        if (a < 0)
        {
            signCounter++;
        }
        if (b < 0)
        {
            signCounter++;
        }
        if (c < 0)
        {
            signCounter++;
        }

        if (signCounter % 2 == 1)
        {
            Console.WriteLine("The sign of the product of the three numbers is +");
        }
        else
        {
            Console.WriteLine("The sign of the product of the three numbers is -");
        }
    }
}
