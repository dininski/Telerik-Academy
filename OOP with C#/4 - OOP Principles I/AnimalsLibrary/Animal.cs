using System;

namespace AnimalsLibrary
{
    public abstract class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public char Sex { get; set; }

        public Animal(string Name, int Age, char Sex)
        {
            this.Name = Name;
            this.Age = Age;
            this.Sex = Sex;
        }
    }
}
