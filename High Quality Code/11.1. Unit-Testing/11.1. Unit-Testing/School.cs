namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using StudentSystem.Exceptions;

    public class School
    {
        private readonly IList<Course> courses;

        public School()
        {
            this.courses = new List<Course>();
        }

        public void AddCourse(Course newCourse)
        {
            if (newCourse == null)
            {
                throw new ArgumentNullException("The course to remove cannot be null!");
            }

            if (this.ContainsCourse(newCourse))
            {
                throw new SchoolException("The course has already been added!");
            }

            this.courses.Add(newCourse);
        }

        public void RemoveCourse(Course courseToRemove)
        {
            if (courseToRemove == null)
            {
                throw new ArgumentNullException("The course to remove cannot be null!");
            }

            if (this.courses.Count == 0)
            {
                throw new SchoolException("There are no registered courses!");
            }
            
            if (!this.ContainsCourse(courseToRemove))
            {
                throw new SchoolException("This course has not been registered in the school!");
            }

            this.courses.Remove(courseToRemove);
        }

        public Course[] GetCourses()
        {
            return this.courses.ToArray();
        }

        private bool ContainsCourse(Course courseToCheck)
        {
            Debug.Assert(courseToCheck != null, "The course to check cannot be null!");
            return this.courses.Contains(courseToCheck);
        }
    }
}