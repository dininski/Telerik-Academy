using System;
using System.Collections.Generic;

//Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors 
//and methods. Dogs, frogs and cats are Animals. All animals can produce sound 
//(specified by the ISound interface). Kittens and tomcats are cats. All animals 
//are described by age, name and sex. Kittens can be only female and tomcats can 
//be only male. Each animal produces a specific sound. Create arrays of different 
//kinds of animals and calculate the average age of each kind of animal using a 
//static method (you may use LINQ).


namespace AnimalsLibrary
{
    class Program
    {
        public static void AverageAge(Animal[] animals)
        {
            //todo
        }

        public static void Main()
        {
            Animal[] differentAnimals = new Animal[13];

            differentAnimals[0] = new Cat("Anastacia", 6, 'F');
            differentAnimals[1] = new Dog("Tilly", 7, 'F');
            differentAnimals[2] = new Dog("Babe", 7, 'F');
            differentAnimals[3] = new Frog("Pipa", 1, 'F');
            differentAnimals[4] = new Tomcat("Tom", 1);
            differentAnimals[5] = new Cat("Princeton", 9, 'M');
            differentAnimals[6] = new Tomcat("Tom", 1);
            differentAnimals[7] = new Kitten("Milly", 3);
            differentAnimals[8] = new Frog("Charles", 1, 'M');
            differentAnimals[9] = new Frog("Wil.I.Am", 3, 'M');
            differentAnimals[10] = new Frog("Wil.I.Am", 3, 'M');
            differentAnimals[11] = new Dog("Padme", 9, 'F');
            differentAnimals[12] = new Kitten("Princess", 1); ;

            AverageAge(differentAnimals);
        }
    }
}
