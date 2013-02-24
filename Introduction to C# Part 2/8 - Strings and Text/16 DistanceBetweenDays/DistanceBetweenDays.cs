using System;

class DistanceBetweenDays
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter first date in the following format DD.MM.YYYY:");
        string[] firstDate = Console.ReadLine().Split('.');
        Console.WriteLine("Please enter second date:");
        string[] secondDate = Console.ReadLine().Split('.');
        DateTime date1 = new DateTime(int.Parse(firstDate[2]), int.Parse(firstDate[1]), int.Parse(firstDate[0]));
        DateTime date2 = new DateTime(int.Parse(secondDate[2]), int.Parse(secondDate[1]), int.Parse(secondDate[0]));
        int difference = (date2 - date1).Days;
        Console.WriteLine("The difference between the two days is {0} days", difference);
    }
}
