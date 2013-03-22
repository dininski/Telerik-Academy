using System;
using System.Text;

//1. Define a class Student, which contains data about a student – first, middle and 
//last name, SSN, permanent address, mobile phone e-mail, course, specialty, 
//university, faculty. Use an enumeration for the specialties, universities and 
//faculties. Override the standard methods, inherited by  System.Object: Equals(),
//ToString(), GetHashCode() and operators == and !=.

//2. Add implementations of the ICloneable interface. The Clone() method should deeply 
//copy all object's fields into a new object of type Student.

//3.Implement the  IComparable<Student> interface to compare students by names (as 
//first criteria, in lexicographic order) and by social security number (as second 
//criteria, in increasing order).


namespace School
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long Ssn { get; set; }
        public string Address { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }
        public Speciality Speciality { get; set; }

        public Student()
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Name: {0} {1} {2}",this.FirstName, this.MiddleName, this.LastName));
            sb.AppendLine(String.Format("SSN: {0}", this.Ssn));
            sb.AppendLine(String.Format("Address: {0}", this.Address));
            sb.AppendLine(String.Format("Phone: {0}", this.Phone));
            sb.AppendLine(String.Format("Email: {0}", this.Email));
            sb.AppendLine(String.Format("University: {0}", this.University));
            sb.AppendLine(String.Format("Faculty: {0}", this.Faculty));
            sb.Append(String.Format("Speciality: {0}", this.Speciality));
            sb.Append(String.Format("Course: {0}", this.Course));
            return sb.ToString();
        }

        public Student(string firstName, string middleName, long ssn, string lastName, string address, long phone, string email, string course, University university, Faculty faculty, Speciality speciality)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Ssn = ssn;
            this.LastName = lastName;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Speciality = speciality;
        }

        public object Clone()
        {
            return new Student(FirstName, MiddleName, Ssn, LastName, Address, Phone, Email, Course, University, Faculty,
                               Speciality);
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) != 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            if (this.MiddleName.CompareTo(other.MiddleName) != 0)
            {
                return this.MiddleName.CompareTo(other.MiddleName);
            }

            if (this.LastName.CompareTo(other.LastName) != 0)
            {
                return this.LastName.CompareTo(other.LastName);
            }

            return this.Ssn.CompareTo(other.Ssn);
        }

        public override bool Equals(object obj)
        {
            Student someStudent = obj as Student;
            
            if ((object)someStudent == null)
            {
                return false;
            }

            if (!this.FirstName.Equals(someStudent.FirstName))
            {
                return false;
            }

            if (!this.MiddleName.Equals(someStudent.MiddleName))
            {
                return false;
            }

            if (!this.LastName.Equals(someStudent.LastName))
            {
                return false;
            }

            if (!this.Ssn.Equals(someStudent.Ssn))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1.Equals(student2));
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.Ssn.GetHashCode() ^ this.LastName.GetHashCode();
        }
    }
}