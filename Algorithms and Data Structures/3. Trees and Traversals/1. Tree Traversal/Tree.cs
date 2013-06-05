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

        public List<Node> FindLongestRoute(int root)
        {
            var firstLongest = new List<Node>();
            var secondLongest = new List<Node>();

            if (tree[root].Count == 0)
            {
                var singleElementRoute = new List<Node>();
                singleElementRoute.Add(new Node(root));
                return singleElementRoute;
            }
            else if (tree[root].Count == 1)
            {
                return GetLongest(tree[root], root);
            }

            foreach (var item in tree[root])
            {
                var currentLength = GetLongest(tree[item.Value], item.Value);
                if (currentLength.Count > secondLongest.Count)
                {
                    if (currentLength.Count > firstLongest.Count)
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

            var result = new List<Node>();
            result.AddRange(firstLongest);
            result.AddRange(new List<Node> { new Node(root) });
            result.AddRange(secondLongest);

            return result;
        }

        public List<Node> GetLongest(List<Node> subtree, int currentNode)
        {
            var routes = new List<List<Node>>();

            if (subtree.Count == 0)
            {
                var children = new List<Node>();
                children.Add(new Node(currentNode));
                return children;
            }

            foreach (var children in subtree)
            {
                var childPaths = GetLongest(tree[children.Value], children.Value);
                routes.Add(childPaths);
            }

            routes.Sort((x, y) => x.Count.CompareTo(y.Count));
            return routes.First();
        }
    }
}
