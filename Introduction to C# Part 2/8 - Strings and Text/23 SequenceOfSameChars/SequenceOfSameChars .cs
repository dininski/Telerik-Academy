using System;
using System.Text.RegularExpressions;

class SequenceOfSameChars
{
    static void Main(string[] args)
    {
        string testString = "aaaaabbbbbcdddeeeedssaa";
        string pattern = @"(.)\1+";
        var mc = Regex.Replace(testString,pattern, "$1");
        foreach (var match in mc)
        {
            Console.Write(match.ToString()[0]);
        }
        Console.WriteLine();
    }
}