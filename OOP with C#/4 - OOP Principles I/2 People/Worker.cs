using System;

namespace PeopleLibrary
{
    class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public decimal MoneyPerHour()
        {
            return (decimal)(WeekSalary / (WorkHoursPerDay*5));
        }

        public Worker(string FirstName, string LastName, decimal WeekSalary, int WorkHoursPerDay)
            : base(FirstName, LastName)
        {
            this.WeekSalary = WeekSalary;
            this.WorkHoursPerDay = WorkHoursPerDay;
        }
    }
}
