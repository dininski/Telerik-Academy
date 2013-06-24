namespace FriendsInNeed
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static Dictionary<Node, List<Connection>> graph;
        static Dictionary<int, Node> nodes;
        static List<int> hospitals;

        public static void Main()
        {
            graph = new Dictionary<Node, List<Connection>>();
            nodes = new Dictionary<int, Node>();
            hospitals = new List<int>();
            string[] totalsString = Console.ReadLine().Split(' ');
            int connectionsCount = int.Parse(totalsString[1]);

            var hospitalsString = Console.ReadLine().Split(' ');

            foreach (var hospital in hospitalsString)
            {
                int val = int.Parse(hospital);
                Node hospitalNode = new Node(val);
                hospitalNode.IsHospital = true;

                nodes.Add(val, hospitalNode);
                graph.Add(nodes[val], new List<Connection>());
                hospitals.Add(val);
            }

            for (int i = 0; i < connectionsCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int firstVal = int.Parse(input[0]);
                int secondVal = int.Parse(input[1]);
                int dist = int.Parse(input[2]);


                if (!nodes.ContainsKey(firstVal))
                {
                    nodes.Add(firstVal, new Node(firstVal));
                }

                if (!nodes.ContainsKey(secondVal))
                {
                    nodes.Add(secondVal, new Node(secondVal));
                }

                if (!graph.ContainsKey(nodes[firstVal]))
                {
                    graph.Add(nodes[firstVal], new List<Connection>());
                }

                if (!graph.ContainsKey(nodes[secondVal]))
                {
                    graph.Add(nodes[secondVal], new List<Connection>());
                }

                graph[nodes[firstVal]].Add(new Connection(nodes[secondVal], dist));
                graph[nodes[secondVal]].Add(new Connection(nodes[firstVal], dist));
            }

            int minDistance = int.MaxValue;

            foreach (var hosp in hospitals)
            {
                int currentDist = 0;

                Dijkstra(nodes[hosp]);

                foreach (var item in graph)
                {
                    if (!item.Key.IsHospital)
                    {
                        currentDist += item.Key.DijkstraDistance;
                    }
                }

                minDistance = Math.Min(currentDist, minDistance);
            }

            Console.WriteLine(minDistance);
        }

        public static void Dijkstra(Node startNode)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var item in graph)
            {
                if (item.Key.Value != startNode.Value)
                {
                    item.Key.DijkstraDistance = int.MaxValue;
                }
            }

            startNode.DijkstraDistance = 0;

            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                var current = queue.Peek();

                if (current.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbour in graph[current])
                {
                    int potentialDistance = current.DijkstraDistance + neighbour.Distance;

                    if (potentialDistance < neighbour.Node.DijkstraDistance)
                    {
                        neighbour.Node.DijkstraDistance = potentialDistance;
                        queue.Enqueue(neighbour.Node);
                    }
                }

                queue.Dequeue();
            }
        }
    }
}
