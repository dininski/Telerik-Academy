using System;
using System.Text.RegularExpressions;

class ParseUrl
{
    static void Main(string[] args)
    {
        string url = "http://www.dev-bg.org/forum/index.php";
        string pattern = @"(.*)://(.*?)/(.*)";
        string[] results = Regex.Split(url, pattern);
        Console.WriteLine("[protocol]={0}", results[1]);
        Console.WriteLine("[server]={0}", results[2]);
        Console.WriteLine("[resource]={0}", results[3]);
    }
}
