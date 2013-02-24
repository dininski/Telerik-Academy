using System;

class GreatestOfFive
{
    static void Main(string[] args)
    {
        int first;
        int second;
        int third;
        int fourth;
        int fifth;

        Console.WriteLine("Please enter the first integer:");
        int.TryParse(Console.ReadLine(), out first);
        Console.WriteLine("Please enter the second integer:");
        int.TryParse(Console.ReadLine(), out second);
        Console.WriteLine("Please enter the third integer:");
        int.TryParse(Console.ReadLine(), out third);
        Console.WriteLine("Please enter the fourth integer:");
        int.TryParse(Console.ReadLine(), out fourth);
        Console.WriteLine("Please enter the fifth integer:");
        int.TryParse(Console.ReadLine(), out fifth);


        if (first >= second && first >= third && first >= fourth && first >= fifth)
        {
            Console.WriteLine("The first number {0} is the biggest number, first");
        }
        else if (second >= third && second >= fourth && second >= fifth)
        {
            Console.WriteLine("The second number {0} is the biggest", second);
        }
        else if (third >= fourth && third >= fifth)
        {
            Console.WriteLine("The third number {0} is the biggest", third);
        }
        else if (fourth >= fifth)
        {
            Console.WriteLine("The fourt number {0} is the biggest", fourth);
        }
        else
        {
            Console.WriteLine("The fifth number {0} is the biggest", fifth);
        }
    }
}

