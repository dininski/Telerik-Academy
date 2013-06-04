using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Maximum_Path
{
    public class Program
    {
        static Dictionary<BigInteger, List<Node>> tree;

        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            tree = new Dictionary<BigInteger, List<Node>>();
            var parents = new List<int>();
            var children = new HashSet<int>();

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string input = Console.ReadLine();
                int parent = int.Parse(input.Substring(1, input.IndexOf("<-") - 1));
                string substr = input.Substring(input.IndexOf("<-") + 3);
                int child = int.Parse(substr.Substring(0, substr.Length - 1));
                if (!tree.ContainsKey(parent))
                {
                    tree.Add(parent, new List<Node>());
                }
                if (!tree.ContainsKey(child))
                {
                    tree.Add(child, new List<Node>());
                }

                var node = new Node(child, parent);
                tree[parent].Add(new Node(child, parent));

                parents.Add(parent);
                children.Add(child);
            }

            int treeRoot = parents.Where(x => !children.Contains(x)).First();

            BigInteger longest = FindLongestRoute(treeRoot);
            Console.WriteLine(longest);
        }

        public class Node
        {
            public BigInteger Value { get; private set; }
            public int Parent { get; private set; }

            public Node(int value, int parent)
            {
                this.Value = value;
                this.Parent = parent;
            }
        }

        public static BigInteger FindLongestRoute(BigInteger root)
        {
            BigInteger firstLongest = root;
            BigInteger secondLongest = root;

            if (tree[root].Count == 0)
            {
                return root;
            }
            else if (tree[root].Count == 1)
            {
                return GetRoute(tree[root], root);
            }

            foreach (var item in tree[root])
            {
                BigInteger currentLength = GetRoute(tree[item.Value], item.Value);
                if (currentLength > secondLongest)
                {
                    if (currentLength > firstLongest)
                    {
                        secondLongest = firstLongest;
                        firstLongest = currentLength;
                    }
                    else
                    {
                        secondLongest = currentLength;
                    }
                }
            }

            return firstLongest + secondLongest + root;
        }

        public static BigInteger GetRoute(List<Node> subtree, BigInteger currentNode)
        {
            List<BigInteger> routes = new List<BigInteger>();
            if (subtree.Count == 0)
            {
                return currentNode;
            }

            foreach (var node in subtree)
            {
                routes.Add(GetRoute(tree[node.Value], node.Value) + currentNode);
            }

            return routes.Max();
        }
    }
}
