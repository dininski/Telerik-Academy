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
        public static void Main()
        {
            Frog[] frogs = new Frog[5];
            frogs[0] = new Frog("Kermit", 5, 'M');
            frogs[1] = new Frog("Piggy", 8, 'F');
            frogs[2] = new Frog("Cookie Monster", 3, 'F');
            frogs[3] = new Frog("Oscar the grouch", 15, 'M');
            frogs[4] = new Frog("Kermit's double", 5, 'M');

            Dog[] dogs = new Dog[5];
            dogs[0] = new Dog("Rex", 1, 'M');
            dogs[1] = new Dog("Sergeant Dirty", 6, 'F');
            dogs[2] = new Dog("Lucky", 7, 'F');
            dogs[3] = new Dog("Unlucky", 2, 'M');
            dogs[4] = new Dog("Tramp", 4, 'M');

            Cat[] cats = new Cat[5];
            cats[0] = new Cat("Tom", 6, 'M');
            cats[1] = new Kitten("Princess", 1);
            cats[2] = new Cat("Jerry", 2, 'F');
            cats[3] = new Tomcat("Behemoth", 1);
            cats[4] = new Cat("Pluto", 7, 'M');



            Console.WriteLine("The average age of the frogs is " + Animal.AverageAge(frogs));
            Console.WriteLine("The average age of the dogs is " + Animal.AverageAge(dogs));
            Console.WriteLine("The average age of the cats is " + Animal.AverageAge(cats));
        }
    }
}
