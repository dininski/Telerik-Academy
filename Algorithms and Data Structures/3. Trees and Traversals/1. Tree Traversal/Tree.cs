namespace TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree
    {
        private int root;
        private readonly Dictionary<int, List<Node>> tree;

        public Tree()
        {
            this.tree = new Dictionary<int, List<Node>>();
        }

        public void AddNode(int parentNode, int childNode)
        {
            if (!tree.ContainsKey(parentNode))
            {
                tree.Add(parentNode, new List<Node>());
            }

            if (!tree.ContainsKey(childNode))
            {
                tree.Add(childNode, new List<Node>());
            }

            tree[parentNode].Add(new Node(childNode));
        }

        // find the root of the tree
        public int GetRoot()
        {
            HashSet<int> children = new HashSet<int>();
            HashSet<int> allElements = new HashSet<int>();

            foreach (var element in tree)
            {
                foreach (var child in element.Value)
                {
                    children.Add(child.Value);
                }
            }

            foreach (var element in tree)
            {
                allElements.Add(element.Key);
            }

            allElements.ExceptWith(children);

            this.root = allElements.First();

            return root;
        }

        // find all the middle elements of the tree
        public string GetMiddleElementsAsString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in tree)
            {
                if (element.Value.Count != 0 && element.Key != this.root)
                {
                    sb.AppendFormat("{0}, ", element.Key);
                }
            }

            return sb.ToString();
        }

        // find all the leafs in the tree
        public string GetLeafsAsString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var element in tree)
            {
                if (element.Value.Count == 0)
                {
                    sb.AppendFormat("{0}, ", element.Key);
                }
            }

            return sb.ToString();
        }

        public string GetLongestPath()
        {
            var rootNodeChildren = tree[root];

            Path longestPath = new Path();
            Path secondLongestPath = new Path();

            foreach (var child in rootNodeChildren)
            {
                Path currentPath = FindLongestPath(child.Value);

                if (currentPath.Length > secondLongestPath.Length)
                {
                    if (currentPath.Length > longestPath.Length)
                    {
                        secondLongestPath = longestPath;
                        longestPath = currentPath;
                    }
                    else
                    {
                        secondLongestPath = currentPath;
                    }
                }
            }

            string result = string.Format("{0} {1}, {2}", longestPath.PathString, root, secondLongestPath.PathString);

            return result;
        }

        private Path FindLongestPath(int root)
        {
            throw new NotImplementedException();
        }

        private class Node
        {
            public int Value { get; private set; }

            public Node(int value)
            {
                this.Value = value;
            }
        }

        private class Path
        {
            public int Length { get; private set; }
            public string PathString { get; private set; }
        }
    }
}
