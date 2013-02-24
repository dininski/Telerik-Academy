using System;
using System.Collections.Generic;

class EachLetterOccurances
{
    static void Main(string[] args)
    {
        Dictionary<char, int> letters = new Dictionary<char, int>();
        Console.WriteLine("Enter some text:");
        string someText = Console.ReadLine().ToLower();
        for (int i = 0; i < someText.Length; i++)
        {
            if (letters.ContainsKey(someText[i]))
            {
                letters[someText[i]]++;
            }
            else
            {
                letters.Add(someText[i], 1);
            }
        }
        foreach (var item in letters)
        {
            Console.WriteLine(item);
        }
    }
}
