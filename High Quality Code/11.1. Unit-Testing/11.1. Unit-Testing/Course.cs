namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StudentSystem.Exceptions;

    public class Course
    {
        private const int MaxStudentsPerCourse = 30;
        private readonly IList<Student> enrolledStudents;

        public Course()
        {
            this.enrolledStudents = new List<Student>();
        }

        public void AddStudent(Student newEnrolledStudent)
        {
            if (this.enrolledStudents.Count > MaxStudentsPerCourse)
            {
                throw new CourseFullException("The course cannot have more than " + MaxStudentsPerCourse + " students");
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
                throw new CourseEmptyException("Cannot remove student from the course, because the course is empty!");
            }

            bool studentIsRegisteredInCourse = this.IsStudentInCourse(studentToRemove);

            if (!studentIsRegisteredInCourse)
            {
                throw new ArgumentException("The student is not registered for this course!");
            }

            this.enrolledStudents.Remove(studentToRemove);
        }

        public Student[] GetStudents()
        {
            return this.enrolledStudents.ToArray();
        }

        private bool IsStudentInCourse(Student studentToFind)
        {
            // TODO: maybe add an assertion?!
            return this.enrolledStudents.Contains(studentToFind);
        }
    }
}
