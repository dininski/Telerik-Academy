using System;
using System.Collections.Generic;

namespace SchoolLibrary
{
    public class Discipline
    {
        public int NumberOfLectures { get; set; }
        public int NumberOfExercises { get; set; }
        public string Name { get; set; }
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
    }
}
