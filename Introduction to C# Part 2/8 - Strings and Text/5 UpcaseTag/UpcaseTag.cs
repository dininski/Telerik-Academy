using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq.Expressions;

class UpcaseTag
{
    static void Main(string[] args)
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string pattern = "<upcase>(.*?)</upcase>";
        StringBuilder parsedText = new StringBuilder();
        text = Regex.Replace(text,pattern, m => m.Groups[1].Value.ToUpper());
        Console.WriteLine(text);
    }
}