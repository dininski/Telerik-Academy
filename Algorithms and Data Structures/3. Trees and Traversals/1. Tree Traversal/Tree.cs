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

        public List<Node> FindLongestRoute()
        {
            var firstLongest = new List<Node>();
            var secondLongest = new List<Node>();

            if (tree[this.root].Count == 0)
            {
                var singleElementRoute = new List<Node>();
                singleElementRoute.Add(new Node(this.root));
                return singleElementRoute;
            }
            else if (tree[root].Count == 1)
            {
                return GetLongest(tree[this.root]);
            }

            foreach (var element in tree[this.root])
            {
                var currentPath = GetLongest(tree[element.Value]);
                currentPath.Add(new Node(element.Value));
                if (currentPath.Count > secondLongest.Count)
                {
                    if (currentPath.Count > firstLongest.Count)
                    {
                        secondLongest = firstLongest;
                        firstLongest = currentPath;
                    }
                    else
                    {
                        secondLongest = currentPath;
                    }
                }
            }

            var result = new List<Node>();
            result.AddRange(firstLongest);
            result.AddRange(new List<Node> { new Node(this.root) });
            result.AddRange(secondLongest);

            return result;
        }

        private List<Node> GetLongest(List<Node> subtree)
        {
            var routes = new List<List<Node>>();

            if (subtree.Count == 0)
            {
                var children = new List<Node>();
                return children;
            }

            foreach (var child in subtree)
            {
                List<Node> childPaths = GetLongest(tree[child.Value]);
                childPaths.Add(new Node(child.Value));
                routes.Add(childPaths);
            }

            routes.Sort((x, y) => y.Count.CompareTo(x.Count));
            return routes.First();
        }
    }
}
