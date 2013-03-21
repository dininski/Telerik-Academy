using System;

namespace Person
{
    public class Person
    {
        public int? Age { get; set; }
        public string Name { get; set; }

        public Person()
        {
            this.Name = null;
            this.Age = null;
        }

        public override string ToString()
        {
            if (Age != null)
            {
                return String.Format("Name: {0}, Age: {1}", this.Name, this.Age);
            }
            else
            {
                return String.Format("Name: {0}, No age specified", this.Name);
            }
        }
    }
}