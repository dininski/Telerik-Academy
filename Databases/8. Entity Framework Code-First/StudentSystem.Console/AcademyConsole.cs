using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.ConsoleDemo
{
    public class AcademyConsole
    {
        public static void Main()
        {
            AcademyContext academy = new AcademyContext();

            using (academy)
            {
                var courses = academy.Courses.Include("Students").ToList();

                foreach (var course in courses)
                {
                    Console.WriteLine("Course name: {0}", course.Name);

                    foreach (var student in course.Students)
                    {
                        Console.WriteLine("Student: {0}", student.Name);
                    }
                }
            }
        }
    }
}
