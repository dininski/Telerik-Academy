using System;
using System.Collections.Generic;

namespace SchoolLibrary
{
    public class School
    {
        private List<ClassOfStudents> studentClasses = new List<ClassOfStudents>();

        public void AddClassOfStudents(ClassOfStudents newStudentClass)
        {
            studentClasses.Add(newStudentClass);
        }

        public void RemoveClassOfStudents(ClassOfStudents StudentClassToRemove)
        {
            studentClasses.Remove(StudentClassToRemove);
        }
    }
}
