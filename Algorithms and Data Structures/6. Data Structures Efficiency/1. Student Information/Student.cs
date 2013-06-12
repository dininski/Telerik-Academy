namespace StudentInformation
{
    using System;
    
    public class Student : IComparable<Student>
    {
        public Student(string fname, string lname)
        {
            this.FirstName = fname;
            this.LastName = lname;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Student other)
        {
            int lastNameComparisonResult = this.LastName.CompareTo(other.LastName);

            if (lastNameComparisonResult == 0)
            {
                return this.FirstName.CompareTo(other.FirstName);    
            }

            return lastNameComparisonResult;
        }
    }
}
