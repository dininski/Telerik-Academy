using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;

class ParseDate
{
    static void Main(string[] args)
    {
        string someStringWithDate = "Today's date is 11.12.1530 and the weather is...medieval. Iron Man was born on 01.04.2010";
        string matchDatePattern = @"\b[0-3][0-9]\.[0-1][0-9]\.[0-9]{4}\b";
        MatchCollection matches = Regex.Matches(someStringWithDate, matchDatePattern);
        List<DateTime> dates = new List<DateTime>();
        foreach (var match in matches)
        {
            dates.Add(DateTime.Parse(match.ToString()));
        }

        foreach (var date in dates)
        {
            Console.WriteLine(date.ToString("d", new CultureInfo("en-CA")));
        }
    }
}
