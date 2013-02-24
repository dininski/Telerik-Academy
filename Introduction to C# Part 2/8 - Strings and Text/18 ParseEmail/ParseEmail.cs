using System;
using System.Text.RegularExpressions;


class ParseEmail
{
    static void Main(string[] args)
    {
        string someString = "you can contact me at nobody@nothing.com or at someone@somewhere.net";
        string emailPattern = @"\b[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}\b";
        MatchCollection emails = Regex.Matches(someString.ToLower(), emailPattern);

        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}

