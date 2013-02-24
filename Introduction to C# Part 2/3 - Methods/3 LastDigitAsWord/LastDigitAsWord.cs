using System;


class LastDigitAsWord
{
    static string NumToWord(int a)
    {
        switch (a%10)
        {
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            case 0:
                return "zero";
        }
        return "";
    }

    static void Main(string[] args)
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Last number is: ");
        Console.WriteLine(NumToWord(number));
    }
}