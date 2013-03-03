using System;

namespace AnimalsLibrary
{
    public class Cat : Animal, ISound
    {
        public Cat(string Name, int Age, char Sex)
            : base(Name, Age, Sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
