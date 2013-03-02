using System;
using System.Linq;
using ProjectLibrary.Students;
using System.Collections;

//Using the extension methods OrderBy() and ThenBy() with lambda expressions sort 
//the students by first name and last name in descending order. Rewrite the same with LINQ.


class SortByName
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
        Student[] groupOfStudents = Student.GetGroupOfStudents();
        var sortedWithLambda = groupOfStudents.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

        Console.WriteLine("All students:");
        PrintCollection(groupOfStudents);

        Console.WriteLine();
        Console.WriteLine("Using Lambda:");
        PrintCollection(sortedWithLambda);
        Console.WriteLine();

        var sortedWithLinq = from s in groupOfStudents
                             orderby s.FirstName, s.LastName descending
                             select s;

        Console.WriteLine();
        Console.WriteLine("Using LINQ:");
        PrintCollection(sortedWithLinq);
    }
}
