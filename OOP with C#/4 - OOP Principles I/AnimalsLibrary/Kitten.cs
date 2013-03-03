using System;

namespace AnimalsLibrary
{
    public class Kitten : Cat
    {
        public Kitten(string Name, int Age)
            : base(Name, Age, 'F')
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Baby female meow!");
        }
    }
}
