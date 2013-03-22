using System;

namespace Person
{
    public class Program
    {
        public static void Main()
        {

            Person ivan = new Person("Ivan", 22);
            Person petkan = new Person("Petkan");
            Console.WriteLine(ivan);
            Console.WriteLine(petkan);
        }
    }
}