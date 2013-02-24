using System;


class SwapPlaces
{
    static void Main()
    {
        Console.WriteLine("Please enter the first number:");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the second number:");
        int secondNumber = int.Parse(Console.ReadLine()); ;
        if (firstNumber > secondNumber)
        {
            secondNumber += firstNumber;
            firstNumber = secondNumber - firstNumber;
            secondNumber = secondNumber - firstNumber;
            Console.WriteLine("Exchanged values. The first number not contains {0} and is smaller than the second number {1}", firstNumber, secondNumber);
        }
        else
        {
            Console.WriteLine("Not swapped. The first number is still {0} and the second is {1}", firstNumber, secondNumber);
        }

    }
}

