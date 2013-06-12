namespace StudentInformation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            StudentOrganizer organizer = new StudentOrganizer();
            organizer.ReadFile("..\\..\\students.txt");
            organizer.PrintStudentsByCourse();
        }
    }
}
