using System;

namespace PeopleLibrary
{
    public class Student : Human
    {
        private double grade;
        public double Grade { get; set; }

        public Student(string FirsName, string LastName, double Grade) : base(FirsName, LastName)
        {
            this.Grade = Grade;
        }
    }
}
