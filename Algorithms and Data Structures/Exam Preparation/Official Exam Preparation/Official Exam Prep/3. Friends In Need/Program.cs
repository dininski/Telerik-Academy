namespace _3.Friends_In_Need
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static int[] distance;
        static int?[] previous;
        static HashSet<int> setOfNodes = new HashSet<int>();
        static int[,] adjMatrix;
        static int[] hospitals;
        static HashSet<int> hospHash;

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            int totalNodes = int.Parse(input[0]);
            int totalVertex = int.Parse(input[1]);
            int totalHospitals = int.Parse(input[2]);
            hospitals = new int[totalHospitals];
            distance = new int[totalNodes];
            previous = new int?[totalNodes];
            adjMatrix = new int[totalNodes, totalNodes];
            hospHash = new HashSet<int>();

            string[] hospitalsString = Console.ReadLine().Split(' ');

            for (int i = 0; i < totalHospitals; i++)
            {
                int hospInt = int.Parse(hospitalsString[i]);
                hospitals[i] = hospInt - 1;
                hospHash.Add(hospInt - 1);
            }

            for (int i = 0; i < totalVertex; i++)
            {
                string[] vertexValues = Console.ReadLine().Split(' ');
                int firstNode = int.Parse(vertexValues[0]);
                int secondNode = int.Parse(vertexValues[1]);
                int weight = int.Parse(vertexValues[2]);

                adjMatrix[firstNode - 1, secondNode - 1] = weight;
                adjMatrix[secondNode - 1, firstNode - 1] = weight;
            }

            int min = int.MaxValue;

            for (int i = 0; i < totalHospitals; i++)
            {
                int current = 0;

                Dijkstra(adjMatrix, hospitals[i]);

                for (int j = 0; j < distance.Length; j++)
                {
                    if (distance[j] != int.MaxValue && !hospHash.Contains(j))
                    {
                        current += distance[j];
                    }
                }

                if (current < min)
                {
                    min = current;
                }
            }

            Console.WriteLine(min);
        }

        public static void Dijkstra(int[,] graph, int source)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                distance[i] = int.MaxValue;
                previous[i] = null;
                setOfNodes.Add(i);
            }

            distance[source] = 0;

            while (setOfNodes.Count != 0)
            {
                int minNode = int.MaxValue;

                foreach (var node in setOfNodes)
                {
                    if (minNode > distance[node])
                    {
                        minNode = node;
                    }
                }

                setOfNodes.Remove(minNode);

                if (minNode == int.MaxValue)
                {
                    break;
                }

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int potencialDistance = distance[minNode] + graph[minNode, i];

                        if (potencialDistance < distance[i])
                        {
                            distance[i] = potencialDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }
        }
    }
}
