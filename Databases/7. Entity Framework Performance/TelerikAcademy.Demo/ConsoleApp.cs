using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.Context;

namespace TelerikAcademy.Demo
{
    public class ConsoleApp
    {
        public static void Main()
        {
            //Task1();
            Task2();
        }

        private static void Task1()
        {
            AcademyContext context = new AcademyContext();

            using (context)
            {
                // without include - total queries: 338
                foreach (var employee in context.Employees)
                {
                    Console.WriteLine("Name: {0} {1} {2}, Department: {3}, Town: {4}",
                        employee.FirstName, employee.MiddleName, employee.LastName,
                        employee.Department, employee.Address.Town);
                }

                // with 2 includes - total queries: 1
                foreach (var employee in context.Employees.Include("Address.Town").Include("Department"))
                {
                    Console.WriteLine("Name: {0} {1} {2}, Department: {3}, Town: {4}",
                        employee.FirstName, employee.MiddleName, employee.LastName,
                        employee.Department, employee.Address.Town);
                }
            }
        }

        private static void Task2()
        {
            AcademyContext context = new AcademyContext();

            using (context)
            {
                // ~1300 queries
                var townsSlow = context.Employees.ToList()
                    .Select(e => e.Address).ToList()
                    .Select(a => a.Town).ToList()
                    .Where(t => t.Name == "Sofia");

                // 4 queries
                var townsFast = context.Employees.Include("Address.Town")
                    .Where(e => e.Address.Town.Name == "Sofia");

                foreach (var item in townsFast)
                {
                    Console.WriteLine(item.Address.Town.Name);
                }
            }
        }
    }
}
