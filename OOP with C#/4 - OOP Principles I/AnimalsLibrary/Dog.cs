using System;

namespace AnimalsLibrary
{
    public class Dog : Animal, ISound
    {
        public Dog(string Name, int Age, char Sex)
            : base(Name, Age, Sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
