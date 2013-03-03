using System;

namespace AnimalsLibrary
{
    public class Frog : Animal, ISound
    {
        public Frog(string Name, int Age, char Sex)
            : base(Name, Age, Sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Ribbit!(I'm a frog not a princess)");
        }
    }
}
