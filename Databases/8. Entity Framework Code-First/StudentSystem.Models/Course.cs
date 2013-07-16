namespace StudentSystem.Models
{
    using System.Collections.Generic;

    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Materials { get; set; }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
    }
}
