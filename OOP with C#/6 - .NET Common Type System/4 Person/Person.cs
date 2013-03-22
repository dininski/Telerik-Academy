using System;

namespace Person
{
    public class Person
    {
        public int? Age { get; set; }
        public string Name { get; set; }

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
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