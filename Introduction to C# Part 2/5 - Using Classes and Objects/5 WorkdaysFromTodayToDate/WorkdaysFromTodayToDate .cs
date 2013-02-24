using System;

class WorkdaysFromTodayToDate 
{
    public static int CalculateRegularWorkingDays(DateTime startDate, DateTime endDate, DateTime[] holidays)
    {
        int result = 0;
        int totalDays = (endDate - startDate).Days;
        for (int i = 0; i < totalDays; i++)
        {
            startDate = startDate.AddDays(1);
            if (startDate.DayOfWeek != DayOfWeek.Sunday && startDate.DayOfWeek != DayOfWeek.Saturday)
            {
                for (int j = 0; j < holidays.Length; j++)
                {
                    if (startDate.Date == holidays[j].Date)
                    {
                        result--;
                    }
                }
                result++;
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        //sample holidays
        DateTime[] holidays = {new DateTime(2013,1,1), new DateTime(2013,2,5), new DateTime(2013,3,4), new DateTime(2013,5,1), new DateTime(2013,12,25)};
        DateTime today = DateTime.Now;
        Console.WriteLine(CalculateRegularWorkingDays(today, new DateTime(2013, 2, 6), holidays));
    }
}