using System;

class OneToAHundredReader
{
    static int bottomLimit = 2;
    static int upperLimit = 99;

    public static void ReadNumber(int start, int end)
    {
        int userNumber = int.Parse(Console.ReadLine());
        if (userNumber > end || userNumber < start)
        {
            throw new ArgumentException();
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("You need to enter 10 numbers that are bigger than 1 and lower than 100");
        try
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Please enter number {0} = ", i + 1);
                ReadNumber(bottomLimit, upperLimit);
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The number was not bigger than {0} and smaller than {1}", bottomLimit - 1, upperLimit + 1);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid argument entered");
        }
    }
}