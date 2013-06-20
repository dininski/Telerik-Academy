namespace _4.LinkedOut
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static Dictionary<string, List<Person>> graph;
        static Dictionary<string, int> linksCount;

        static string rootPerson;

        static void Main(string[] args)
        {
            linksCount = new Dictionary<string, int>();
            graph = new Dictionary<string, List<Person>>();
            rootPerson = Console.ReadLine();
            graph.Add(rootPerson, new List<Person>());

            int numberOfConnections = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfConnections; i++)
            {
                string[] pairStrings = Console.ReadLine().Split(' ');
                string parent = pairStrings[0];
                string childName = pairStrings[1];
                if (!graph.ContainsKey(parent))
                {
                    graph.Add(parent, new List<Person>());
                }

                if (!graph.ContainsKey(childName))
                {
                    graph.Add(childName, new List<Person>());
                }

                graph[parent].Add(new Person(childName));
                graph[childName].Add(new Person(parent));

            }

            int peopleToFind = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleToFind; i++)
            {
                string person = Console.ReadLine();

                if (linksCount.ContainsKey(person))
                {
                    Console.WriteLine(linksCount[person]);
                }
                else
                {
                    int level = FindPerson(person);
                    Console.WriteLine(level);
                }
            }
        }

        static int FindPerson(string personToFind)
        {
            var bfs = new Queue<Person>();

            HashSet<string> visited = new HashSet<string>();

            bfs.Enqueue(new Person(rootPerson));

            while (bfs.Count != 0)
            {
                Person current = bfs.Dequeue();
                visited.Add(current.Name);

                if (!linksCount.ContainsKey(current.Name))
                {
                    linksCount.Add(current.Name, current.Level);
                }

                if (current.Name.Equals(personToFind))
                {
                    return current.Level;
                }
                else
                {
                    foreach (var child in graph[current.Name])
                    {
                        if (!linksCount.ContainsKey(child.Name))
                        {
                            linksCount.Add(child.Name, current.Level + 1);
                        }

                        if (!visited.Contains(child.Name))
                        {
                            bfs.Enqueue(new Person(child.Name, current.Level + 1));
                        }
                    }
                }
            }

            return -1;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public Person(string name)
            : this(name, 0)
        {
        }

        public Person(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }
    }
}