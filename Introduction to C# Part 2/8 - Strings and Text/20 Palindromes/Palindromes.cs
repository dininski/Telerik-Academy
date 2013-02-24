using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Palindromes
{
    public static bool IsPalindrome(string word)
    {
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }


    static void Main(string[] args)
    {
        List<string> palindromes = new List<string>();
        string someText = "This some text that has some palindromes: abba, bob, aibohphobia";
        Console.WriteLine("Text to evaluate:");
        Console.WriteLine(someText);
        string wordPattern = @"\b\w+\b";
        MatchCollection words = Regex.Matches(someText, wordPattern);
        foreach (var word in words)
        {
            if (IsPalindrome(word.ToString()))
            {
                palindromes.Add(word.ToString());
            }
        }
        Console.WriteLine("Palindromes:");
        foreach (var item in palindromes)
        {
            Console.Write("{0} ", item);
        }
        Console.WriteLine();
    }
}
