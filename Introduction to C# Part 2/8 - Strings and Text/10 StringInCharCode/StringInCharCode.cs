using System;

class StringInCharCode
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a string:");
        string userInput = Console.ReadLine();
        for (int i = 0; i < userInput.Length; i++)
        {
            Console.Write("\\u{0:x4}", (int)userInput[i]);
        }
    }
}
