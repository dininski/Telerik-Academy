using System;
using System.Globalization;

class SixHoursLaterInBG
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter date in the format DD.MM.YYYY HH:MM:SS");
        string[] date = Console.ReadLine().Split(new char[] { ' ', ':', '.' });
        DateTime inputDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(date[3]), int.Parse(date[4]), int.Parse(date[5]));
        inputDate = inputDate.AddHours(6).AddMinutes(30);

        Console.WriteLine(inputDate.ToString("dddd", new CultureInfo("bg-BG")));
    }
}