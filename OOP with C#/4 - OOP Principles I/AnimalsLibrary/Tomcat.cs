using System;

namespace AnimalsLibrary
{
    class Tomcat:Cat
    {
        public Tomcat(string Name, int Age)
            : base(Name, Age, 'M')
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("MEOW! I'm a baby cat!");
        }
    }
}
