using System;

class TodaysWeekday
{
    static void Main(string[] args)
    {
        DateTime today = DateTime.Now;
        Console.WriteLine("Today is {0}.", today.DayOfWeek);
    }
}