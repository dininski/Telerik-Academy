namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using StudentSystem.Exceptions;

    public class Course
    {
        private const int MaxStudentsPerCourse = 30;
        
        private readonly IList<Student> enrolledStudents;

        public Course(string courseName)
        {
            this.enrolledStudents = new List<Student>();
            this.CourseName = courseName;
        }

        public string CourseName { get; set; }

        public void AddStudent(Student newEnrolledStudent)
        {
            if (this.enrolledStudents.Count == MaxStudentsPerCourse)
            {
                throw new CourseException("The course cannot have more than " + MaxStudentsPerCourse + " students");
            }

            bool studentIsAlreadyRegistered = this.IsStudentInCourse(newEnrolledStudent);

            if (studentIsAlreadyRegistered)
            {
                throw new ArgumentException("This student is already registered for the course!");
            }

            this.enrolledStudents.Add(newEnrolledStudent);
        }

        public void RemoveStudent(Student studentToRemove)
        {
            if (this.enrolledStudents.Count == 0)
            {
                throw new CourseException("Cannot remove student from the course, because the course is empty!");
            }

            bool studentIsRegisteredInCourse = this.IsStudentInCourse(studentToRemove);

            if (studentIsRegisteredInCourse == false)
            {
                throw new ArgumentException("The student is not registered for this course!");
            }

            this.enrolledStudents.Remove(studentToRemove);
        }

        public Student[] GetStudents()
        {
            return this.enrolledStudents.ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Course name: {0}", this.CourseName));
            foreach (var student in this.enrolledStudents)
            {
                sb.AppendLine(student.ToString());
            }

            return sb.ToString();
        }

        private bool IsStudentInCourse(Student studentToFind)
        {
            Debug.Assert(studentToFind != null, "The student to find cannot be null!");
            return this.enrolledStudents.Contains(studentToFind);
        }
    }
}
