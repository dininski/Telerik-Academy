namespace StudentSystem
{
    using StudentSystem.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class School
    {
        private readonly IList<Course> courses;

        public School()
        {
            courses = new List<Course>();
        }

        public void AddCourse(Course newCourse)
        {
            if (this.ContainsCourse(newCourse))
            {
                throw new SchoolException("The course has already been added!");
            }

            if (newCourse == null)
            {
                throw new ArgumentNullException("The course to remove cannot be null!");
            }

            courses.Add(newCourse);
        }

        public void RemoveCourse(Course courseToRemove)
        {
            if (courses.Count == 0)
            {
                throw new SchoolException("There are no registered courses!");
            }

            if (courseToRemove == null)
            {
                throw new ArgumentNullException("The course to remove cannot be null!");
            }
            
            if (!this.ContainsCourse(courseToRemove))
            {
                throw new SchoolException("This course has not been registered in the school!");
            }

            this.courses.Remove(courseToRemove);
        }

        private bool ContainsCourse(Course courseToCheck)
        {
            Debug.Assert(courseToCheck != null);
            return this.courses.Contains(courseToCheck);
        }
    }
}