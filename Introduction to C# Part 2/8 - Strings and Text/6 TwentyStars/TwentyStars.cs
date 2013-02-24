using System;

class TwentyStars
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter some text:");
        string text = Console.ReadLine();
        text = text.PadRight(20, '*');
        Console.WriteLine(text);
    }
}