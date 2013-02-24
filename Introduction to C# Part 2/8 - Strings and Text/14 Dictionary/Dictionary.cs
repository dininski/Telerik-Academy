using System;
using System.Text.RegularExpressions;

class Dictionary
{
    static void Main(string[] args)
    {
        string dictionary =
@".NET – platform for applications from Microsoft
CLR – managed execution environment for .NET
namespace – hierarchical organization of classes";
        //string searchedWord = Console.ReadLine();
        string searchedWord = ".NET";
        //no regular expressions
        int wordStartAtPos = dictionary.IndexOf(searchedWord);
        if (wordStartAtPos >= 0)
        {
            if (wordStartAtPos == 0 || dictionary.IndexOf("\n", wordStartAtPos - 2) == wordStartAtPos - 1)
            {
                Console.WriteLine("Finding the word without Regular Expressions:");
                if (dictionary.LastIndexOf("\n") > wordStartAtPos)
                {
                    Console.WriteLine(dictionary.Substring(wordStartAtPos, dictionary.IndexOf("\n", wordStartAtPos) - wordStartAtPos));
                }
                else
                {
                    Console.WriteLine(dictionary.Substring(wordStartAtPos, dictionary.Length-wordStartAtPos));
                }
            }
        }
        else
        {
            Console.WriteLine("Cannot find the word in the dictionary.");
        }
        //with regular expressions:
        string pattern = string.Format(@"\b?{0}\b – (.*?)\n", searchedWord);
        var result = Regex.Match(dictionary, pattern);
        Console.WriteLine(result.ToString().Remove(result.Length-1));
    }
}