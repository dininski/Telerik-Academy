using System;

class SquareRoot
{
    public static void CheckIfNegative(int number)
    {
        if (number < 0)
        {
            throw new ArithmeticException();
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a positive integer:");
        try
        {
            int userNumber = int.Parse(Console.ReadLine());
            CheckIfNegative(userNumber);
            Console.WriteLine("Square root of {0} is {1}", userNumber, Math.Sqrt(userNumber));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number - the number is too big.");
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("The number must not be negative");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}