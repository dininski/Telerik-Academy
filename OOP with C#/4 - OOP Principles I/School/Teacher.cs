using System;
using System.Collections.Generic;

namespace SchoolLibrary
{
    public class Teacher : Person, IComment
    {
        private List<Discipline> disciplines = new List<Discipline>();
        private List<string> comments = new List<string>();

        public Teacher(string name)
            : base(name)
        {
        }

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

        public void AddDiscipline(Discipline newDiscipline)
        {
            disciplines.Add(newDiscipline);
        }

        public void RemoveDiscipline(Discipline disciplineToRemove)
        {
            disciplines.Remove(disciplineToRemove);
        }
    }
}
