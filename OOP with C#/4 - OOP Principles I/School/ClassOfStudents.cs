using System;
using System.Collections.Generic;

namespace SchoolLibrary
{
    public class ClassOfStudents : IComment
    {
        private List<Teacher> teachers = new List<Teacher>();
        private List<Student> students = new List<Student>();
        private List<string> comments = new List<string>();

        public string Id { get; set; }

        public string[] Comment
        {
            get
            {
                return this.comments.ToArray();
            }
        }

        public void AddComment(string newComment)
        {
            comments.Add(newComment);
        }

        public void AddTeacher(Teacher newTeacher)
        {
            teachers.Add(newTeacher);
        }

        public void RemoveTeacher(Teacher teacherToRemove)
        {
            teachers.Remove(teacherToRemove);
        }

        public void AddStudent(Student newStudent)
        {
            students.Add(newStudent);
        }

        public void RemoveStudent(Student studentToRemove)
        {
            students.Remove(studentToRemove);
        }
    }
}
