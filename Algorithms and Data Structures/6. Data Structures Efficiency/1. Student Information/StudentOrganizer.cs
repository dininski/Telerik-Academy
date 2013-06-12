namespace StudentInformation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Wintellect.PowerCollections;

    public class StudentOrganizer
    {
        SortedDictionary<string, OrderedBag<Student>> students;

        public StudentOrganizer()
        {
            this.students = new SortedDictionary<string, OrderedBag<Student>>();
        }

        public void ReadFile(string file)
        {
            StreamReader sr = new StreamReader(file);

            using (sr)
            {
                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();
                    string[] parameters = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string fname = parameters[0].Trim();
                    string lname = parameters[1].Trim();
                    string course = parameters[2].Trim();
                    if (!this.students.ContainsKey(course))
                    {
                        this.students.Add(course, new OrderedBag<Student>());
                    }

                    Student currentStudent = new Student(fname, lname);
                    this.students[course].Add(currentStudent);
                }
            }
        }

        public void PrintStudentsByCourse()
        {
            foreach (var course in students)
            {
                Console.WriteLine("Course {0}: ", course.Key);

                foreach (var student in students[course.Key])
                {
                    Console.Write("{0} {1}, ", student.FirstName, student.LastName);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
