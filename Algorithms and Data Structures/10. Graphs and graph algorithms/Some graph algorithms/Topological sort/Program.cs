namespace TopologicalSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static Dictionary<int, List<Node>> children;
        static Dictionary<int, Node> nodes;

        static void Main(string[] args)
        {
            int numberOfConnections = int.Parse(Console.ReadLine());
            children = new Dictionary<int, List<Node>>();
            nodes = new Dictionary<int, Node>();
            for (int i = 0; i < numberOfConnections; i++)
            {
                string[] vertexAsString = Console.ReadLine().Split(' ');
                int parent = int.Parse(vertexAsString[0]);
                int child = int.Parse(vertexAsString[1]);

                if (!children.ContainsKey(parent))
                {
                    children.Add(parent, new List<Node>());
                }

                if (!children.ContainsKey(child))
                {
                    children.Add(child, new List<Node>());
                }

                if (!nodes.ContainsKey(child))
                {
                    Node childNode = new Node(child);
                    nodes.Add(child, childNode);
                }

                if (!nodes.ContainsKey(parent))
                {
                    Node parentNode = new Node(parent);
                    nodes.Add(parent, parentNode);
                }

                nodes[child].NumberOfParents++;

                children[parent].Add(nodes[child]);
            }

            List<Node> noParents = new List<Node>();

            foreach (var node in nodes)
            {
                if (node.Value.NumberOfParents == 0)
                {
                    noParents.Add(node.Value);
                }
            }

            while (noParents.Count != 0)
            {
                var parent = noParents[0];

                foreach (var child in children[parent.Val])
                {
                    child.NumberOfParents--;
                    if (child.NumberOfParents == 0)
                    {
                        noParents.Add(child);
                    }
                }
                Console.WriteLine(parent.Val);
                noParents.Remove(parent);
            }

        }

        private class Node
        {
            public Node(int val)
            {
                this.Val = val;
                this.NumberOfParents = 0;
            }

            public int NumberOfParents { get; set; }
            public int Val { get; set; }
        }
    }
}
