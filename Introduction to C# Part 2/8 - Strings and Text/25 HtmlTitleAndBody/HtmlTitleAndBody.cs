using System;
using System.Text.RegularExpressions;

class HtmlTitleAndBody
{
    static void Main(string[] args)
    {
        string html = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";

        //1st variant regex to remove the tags
        string pattern = @"</?(.*?)>";
        var noTags = Regex.Replace(html, pattern, string.Empty);
        Console.WriteLine(noTags);

        //2nd variant regex to read what is between the tags
        pattern = @">(.*?)<";
        var textBetweenTags = Regex.Matches(html, pattern);
        foreach (Match item in textBetweenTags)
        {
            if (!string.IsNullOrEmpty(item.Groups[1].Value))
            {
                Console.WriteLine(item.Groups[1]);
            }
        }
    }
}
