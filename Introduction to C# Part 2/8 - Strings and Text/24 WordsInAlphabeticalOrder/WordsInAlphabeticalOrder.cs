using System;

class WordsInAlphabeticalOrder
{
    static void Main(string[] args)
    {
        string wordsSeparatedBySpace = "test some word die hard spiderman i am god";
        string[] words = wordsSeparatedBySpace.Split(' ');
        Array.Sort(words);
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}