using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    public class Professions
    {
        public string name;
        public int rating;
    }

    public class Employee
    {
        public string firstName;
        public string secondName;
        public int rating;
    }

    static void Main(string[] args)
    {
        int jobPositions = int.Parse(Console.ReadLine());
        Professions[] positions = new Professions[jobPositions];
        for (int i = 0; i < jobPositions; i++)
        {
            positions[i] = new Professions();
            String temp = Console.ReadLine();
            String[] parsed = temp.Split('-');
            parsed[0] = parsed[0].Substring(0, parsed[0].Length - 1);
            positions[i].name = parsed[0];
            positions[i].rating = Convert.ToInt32(parsed[1]);
        }

        int totalEmployees = int.Parse(Console.ReadLine());
        Employee[] allEmployees = new Employee[totalEmployees];
        for (int i = 0; i < totalEmployees; i++)
        {
            allEmployees[i] = new Employee();
            String temp = Console.ReadLine();
            String[] parsed = temp.Split('-');
            String[] names = parsed[0].Split();
            parsed[1] = parsed[1].Substring(1, parsed[1].Length - 1);
            //            String[] parsed = Regex.Split(temp, "(.*) (.*) - (.*)");
            allEmployees[i].firstName = names[0];
            allEmployees[i].secondName = names[1];
            allEmployees[i].rating = positions.First(x => x.name == parsed[1]).rating;
        }

        allEmployees = allEmployees.OrderByDescending(x=>x.rating).ThenBy(x=>x.secondName).ThenBy(x=>x.firstName).ToArray();

        foreach (var item in allEmployees)
        {
            Console.Write("{0} {1}\n", item.firstName, item.secondName);
        }
    }
}