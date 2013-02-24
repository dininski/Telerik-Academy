using System;
using System.Text;

class ReverseString
{
    static void Main(string[] args)
    {
        string userInput = Console.ReadLine();
        StringBuilder reversed = new StringBuilder();
        for (int i = userInput.Length-1; i >= 0; i--)
        {
            reversed.Append(userInput[i]);
        }
        Console.WriteLine("Original string: {0}", userInput);
        Console.WriteLine("Reversed string: {0}", reversed);
    }
}