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

        public static double AverageAge(Animal[] animals)
        {
            double ages = 0;
            for (int i = 0; i < animals.Length; i++)
            {
                ages += animals[i].Age;
            }
            return ages / animals.Length;
        }
    }
}
