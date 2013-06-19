using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Friends_In_Need
{
    class Program
    {
        static int[] distance;
        static int?[] previous;
        static HashSet<int> setOfNodes = new HashSet<int>();
        static int nodeCount;

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

        static void Main(string[] args)
        {
            string[] generalNodesString = Console.ReadLine().Split(' ');
            string[] hospitalsString = Console.ReadLine().Split(' ');
            var hospHash = new HashSet<int>();

            nodeCount = int.Parse(generalNodesString[0]);
            int vertexCount = int.Parse(generalNodesString[1]);
            int hospitalCount = int.Parse(generalNodesString[2]);

            int[,] graph = new int[nodeCount + 1, nodeCount + 1];

            int[] hospitals = new int[hospitalCount];
            for (int i = 0; i < hospitalCount; i++)
            {
                hospitals[i] = int.Parse(hospitalsString[i]);
                hospHash.Add(hospitals[i]);
            }

            ClearHolders();

            for (int i = 0; i < vertexCount; i++)
            {
                string[] vertexValues = Console.ReadLine().Split(' ');
                int parent = int.Parse(vertexValues[0]);
                int child = int.Parse(vertexValues[1]);
                int weight = int.Parse(vertexValues[2]);

                graph[parent, child] = weight;
                graph[child, parent] = weight;
            }

            int min = int.MaxValue;

            for (int i = 0; i < hospitals.Count(); i++)
            {
                int current = 0;
                Dijkstra(graph, hospitals[i]);
                for (int j = 1; j < distance.Length; j++)
                {
                    if (!hospHash.Contains(j))
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

        public static void ClearHolders()
        {
            distance = new int[nodeCount + 1];
            previous = new int?[nodeCount + 1];
        }
    }
}
