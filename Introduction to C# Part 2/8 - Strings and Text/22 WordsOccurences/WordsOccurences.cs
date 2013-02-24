using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class WordsOccurences
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter string:");
        string userInput = Console.ReadLine();
        string wordPattern = @"\b(\w.*?)\b";
        Dictionary<string, int> words = new Dictionary<string, int>();
        MatchCollection matches = Regex.Matches(userInput.ToLower(), wordPattern);
        foreach (var match in matches)
        {
            if (words.ContainsKey(match.ToString()))
            {
                words[match.ToString()]++;
            }
            else
            {
                words.Add(match.ToString(), 1);
            }
        }

        foreach (var item in words)
        {
            Console.WriteLine(item);
        }
    }
}
