using System;
using System.Linq;
using System.Collections.Generic;

/*Define abstract class Human with first name and last name. Define new class Student 
 * which is derived from Human and has new field – grade. Define class Worker derived 
 * from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() 
 * that returns money earned by hour by the worker. Define the proper constructors and 
 * properties for this hierarchy. Initialize a list of 10 students and sort them by 
 * grade in ascending order (use LINQ or OrderBy() extension method). Initialize a list 
 * of 10 workers and sort them by money per hour in descending order. Merge the lists 
 * and sort them by first name and last name.
*/

namespace PeopleLibrary
{
    class Program
    {
        static List<Worker> brigade = new List<Worker>();
        static List<Student> academy = new List<Student>();
        static List<Human> merged = new List<Human>();

        public static void Main()
        {
            PrintLabel("Unordered:");
            FillBrigade();
            FillAcademy();
            PrintAcademy();
            PrintBrigade();
            brigade = brigade.OrderBy(x => x.MoneyPerHour()).Reverse().ToList();
            academy = academy.OrderBy(x => x.Grade).Reverse().ToList();
            PrintLabel("Ordered:");
            PrintAcademy();
            PrintBrigade();
            merged.AddRange(brigade);
            merged.AddRange(academy);
            merged = merged.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            PrintLabel("All together:");
            Console.WriteLine("note : Workers have bulgarian names, students have foreign names");
            Console.WriteLine();
            foreach (var item in merged)
            {
                Console.WriteLine("First Name: {0,-10} Last Name: {1}", item.FirstName, item.LastName);
            }
        }

        private static void PrintLabel(string label)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(label);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }

        private static void PrintBrigade()
        {
            foreach (var item in brigade)
            {
                Console.WriteLine("Name: {0} {1} \nmoney/hour: {2:.00}", item.FirstName, item.LastName, item.MoneyPerHour());
                Console.WriteLine();
            }
        }

        private static void PrintAcademy()
        {
            foreach (var item in academy)
            {
                Console.WriteLine("Name: {0} {1} \ngrade: {2:.00}", item.FirstName, item.LastName, item.Grade);
                Console.WriteLine();
            }
        }

        //workers has bulgarian names
        private static void FillBrigade()
        {
            brigade.Add(new Worker("Georgi", "Pepkov", 300, 6));
            brigade.Add(new Worker("Vasil", "Tihomirov", 400, 3));
            brigade.Add(new Worker("Silvano", "Kilimandjarov", 500, 9));
            brigade.Add(new Worker("Veselin", "Marinov", 200, 12));
            brigade.Add(new Worker("Prilep", "Popov", 300, 6));
            brigade.Add(new Worker("Ivanina", "Tutkova", 400, 3));
            brigade.Add(new Worker("Kalina", "Malinkova", 500, 9));
            brigade.Add(new Worker("Pepa", "Ananasova", 200, 12));
            brigade.Add(new Worker("Katerina", "Tropkova", 300, 6));
            brigade.Add(new Worker("Anna", "Filarionova", 400, 3));
        }

        //student have american/english/space names
        private static void FillAcademy()
        {
            academy.Add(new Student("Richard", "Castle", 5.3));
            academy.Add(new Student("Luke", "Skywalker", 3.5));
            academy.Add(new Student("Bilbo", "Baggins", 2.8));
            academy.Add(new Student("Walter", "White", 6.1));
            academy.Add(new Student("John", "Anderson", 1.5));
            academy.Add(new Student("Lisbeth", "Salander", 3.7));
            academy.Add(new Student("Carrie", "White", 4.1));
            academy.Add(new Student("Clarice", "Starling", 5.2));
            academy.Add(new Student("Mia", "Wallace", 1.1));
            academy.Add(new Student("Scarlett", "O'Hara", 0.2));
        }
    }
}
