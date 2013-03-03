using System;

namespace SchoolLibrary
{
    public abstract class Person
    {
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Person(string name)
        {
            this.name = name;
        }
    }
}
