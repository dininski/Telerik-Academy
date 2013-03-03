using System;
using System.Linq;
using ProjectLibrary.Students;
using System.Collections;

//Write a method that from a given array of students finds all students whose 
//first name is before its last name alphabetically. Use LINQ query operators.

class StudentNames
{

    public static void PrintCollection(IEnumerable students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine("Name: {0} {1}, Age: {2}", student.FirstName, student.LastName, student.Age);
        }
    }

    static void Main(string[] args)
    {
        //group of students consists of 10 students
        Student[] groupOfStudents = Student.GetGroupOfStudents();

        var selectedStudents = from s in groupOfStudents
                               where string.Compare(s.FirstName, s.LastName) < 0
                               select s;

        Console.WriteLine("All students:");
        Console.WriteLine();
        PrintCollection(groupOfStudents);

        Console.WriteLine();
        Console.WriteLine("Students with first name before last name alpabetically: ");
        Console.WriteLine();

        //we've received only 4 students
        PrintCollection(selectedStudents);
    }
}