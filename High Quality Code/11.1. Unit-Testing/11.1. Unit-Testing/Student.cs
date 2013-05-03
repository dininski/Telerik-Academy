namespace StudentSystem
{
    using System;

    public class Student
    {
        private int id;
        private string name;

        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException(
                        "The student ID number must be in larger than 10 000 and smaller than 99 999!");
                }

                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("The student name cannot be empty!");
                }

                this.name = value;
            }
        }
    }
}
