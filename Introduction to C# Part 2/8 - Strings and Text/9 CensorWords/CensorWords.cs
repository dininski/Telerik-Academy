using System;
using System.Text;
using System.Text.RegularExpressions;

class CensorWords
{
    static void Main(string[] args)
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string forbiddenWords = "PHP, CLR, Microsoft";
        string[] forbidden = forbiddenWords.Split(',');
        for (int i = 0; i < forbidden.Length; i++)
        {
            string pattern = String.Format(@"\b{0}\b", forbidden[i].Trim());
            text = Regex.Replace(text,pattern,new string('*',forbidden[i].Length));
        }
        Console.WriteLine(text);
    }
}
