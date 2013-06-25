using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _4.Recover_Message
{
    class Program
    {
        static OrderedDictionary<char, Node> graph;

        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            graph = new OrderedDictionary<char, Node>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string currentInput = Console.ReadLine();
                if (!graph.ContainsKey(currentInput[0]))
                {
                    graph.Add(currentInput[0], new Node(currentInput[0]));
                }

                for (int l = 1; l < currentInput.Length; l++)
                {
                    var currentChar = currentInput[l - 1];
                    var nextChar = currentInput[l];

                    if (!graph.ContainsKey(currentChar))
                    {
                        graph.Add(currentChar, new Node(currentChar));
                    }

                    if (!graph.ContainsKey(nextChar))
                    {
                        graph.Add(nextChar, new Node(nextChar));
                    }

                    graph[currentChar].Children.Add(graph[nextChar]);
                    graph[nextChar].Parents++;
                }
            }

            int used = 0;
            PriorityQueue queue = new PriorityQueue();

            StringBuilder sb = new StringBuilder();

            while (used < graph.Count)
            {
                foreach (var node in graph)
                {
                    if (node.Value.Parents == 0 && !queue.Contains(node.Value))
                    {
                        queue.Enqueue(node.Value);
                    }
                }

                if (queue.Count > 0)
                {
                    var current = queue.Dequeue();

                    foreach (var child in current.Children)
                    {
                        child.Parents--;
                    }

                    graph.Remove(current.Value);
                    sb.Append(current.Value);
                }
            }

            Console.WriteLine(sb.ToString());
        }

        public class Node : IComparable<Node>
        {
            public Node(char val)
            {
                this.Value = val;
                this.Parents = 0;
                this.Children = new List<Node>();
            }

            public List<Node> Children { get; set; }
            public char Value { get; set; }
            public int Parents { get; set; }

            public override int GetHashCode()
            {
                return this.Value.GetHashCode();
            }

            public int CompareTo(Node other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }

        public class PriorityQueue
        {
            OrderedBag<Node> elements;

            public PriorityQueue()
            {
                this.elements = new OrderedBag<Node>();
            }

            public int Count
            {
                get
                {
                    return this.elements.Count;
                }
            }

            public void Enqueue(Node newNode)
            {
                this.elements.Add(newNode);
            }

            public Node Dequeue()
            {
                var nodeToReturn = this.elements.GetFirst();
                this.elements.RemoveFirst();
                return nodeToReturn;
            }

            public bool Contains(Node node)
            {
                return this.elements.Contains(node);
            }

            public Node Peek()
            {
                return this.elements.First();
            }
        }
    }
}