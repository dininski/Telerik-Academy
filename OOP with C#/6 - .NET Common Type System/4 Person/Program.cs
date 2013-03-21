using System;

namespace Person
{
    public class Program
    {
        public static void Main()
        {

            Person someone = new Person();
            Person someoneElse = new Person();
            someone.Name = "Ivan";
            someone.Age = 22;
            someoneElse.Name = "Petkan";
            Console.WriteLine(someone);
            Console.WriteLine(someoneElse);
        }
    }
}