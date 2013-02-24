using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class ParseUrl
{
    static void Main(string[] args)
    {
        string html = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        string openAPattern = @"<a href=""(.*?)"">";
        string openUrlPattern = "[URL=$1]";
        string closeUrlPattern = "[/URL]";
        string closeAPattern = "</a>";
        string a;
        a = Regex.Replace(html, openAPattern, openUrlPattern);
        a = Regex.Replace(a, closeAPattern, closeUrlPattern);
        Console.WriteLine(a);
    }
}
