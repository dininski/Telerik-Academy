using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLibrary
{
    public class Student : Person, IComment
    {
        private List<string> comments = new List<string>();

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

        public int ClassNumber { get; set; }

        public Student(string name)
            : base(name)
        {
        }
    }
}
