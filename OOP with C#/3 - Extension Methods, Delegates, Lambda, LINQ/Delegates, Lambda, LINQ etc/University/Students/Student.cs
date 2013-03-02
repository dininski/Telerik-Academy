using System;

namespace ProjectLibrary.Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student(string FirstName, string LastName, int Age)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }

        public static Student[] GetGroupOfStudents()
        {
            Student[] groupOfStudents = new Student[12];
            groupOfStudents[0] = new Student("Michael", "Jordan", 50);
            groupOfStudents[1] = new Student("Ricky", "Rubio", 22);
            groupOfStudents[2] = new Student("Lebron", "James", 28);
            groupOfStudents[3] = new Student("Vince", "Carter", 36);
            groupOfStudents[4] = new Student("Jason", "Kidd", 39);
            groupOfStudents[5] = new Student("Shaquille", "O'Neal", 40);
            groupOfStudents[6] = new Student("Kyrie", "Irving", 20);
            groupOfStudents[7] = new Student("Bill", "Russell", 79);
            groupOfStudents[8] = new Student("Anthony", "Davis", 19);
            groupOfStudents[9] = new Student("Gordon", "Hayward", 22);
            groupOfStudents[10] = new Student("Ray", "Allen", 37);
            groupOfStudents[11] = new Student("Raja", "Bell", 36);

            return groupOfStudents;
        }
    }
}
