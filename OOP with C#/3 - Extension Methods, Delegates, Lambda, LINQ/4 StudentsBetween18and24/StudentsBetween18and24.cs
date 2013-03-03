using System;
using System.Linq;
using ProjectLibrary.Students;
using System.Collections;

//Write a LINQ query that finds the first name and last name of all 
//students with age between 18 and 24.

public class StudentsBetween18and24
{

    public static void PrintCollection(IEnumerable students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}", student.FirstName, student.LastName, student.Age);
        }
    }

    public static void Main()
    {
        Student[] students = Student.GetGroupOfStudents();

        var studentsInRange = from s in students
                              where s.Age > 17 && s.Age < 25
                              select s;

        Console.WriteLine("All students: ");
        PrintCollection(students);
        Console.WriteLine();
        Console.WriteLine("Students that are older than 18 and younger than 24:");
        PrintCollection(studentsInRange);
    }
}
