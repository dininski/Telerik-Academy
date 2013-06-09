namespace TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree
    {
        private int root;
        private readonly Dictionary<int, List<int>> tree;

        public Tree()
        {
            this.tree = new Dictionary<int, List<int>>();
        }

        public void AddNode(int parentNode, int childNode)
        {
            if (!tree.ContainsKey(parentNode))
            {
                tree.Add(parentNode, new List<int>());
            }

            if (!tree.ContainsKey(childNode))
            {
                tree.Add(childNode, new List<int>());
            }

            tree[parentNode].Add(childNode);
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
                    children.Add(child);
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

        // get a list with the longest route
        public List<int> FindLongestRoute()
        {
            var firstLongest = new List<int>();
            var secondLongest = new List<int>();

            if (tree[this.root].Count == 0)
            {
                var singleElementRoute = new List<int>();
                singleElementRoute.Add(this.root);
                return singleElementRoute;
            }
            else if (tree[root].Count == 1)
            {
                return GetLongest(tree[this.root]);
            }

            foreach (var element in tree[this.root])
            {
                var currentPath = GetLongest(tree[element]);
                currentPath.Add(element);

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

            var result = new List<int>();
            result.AddRange(firstLongest);
            result.Add(this.root);
            secondLongest.Reverse();
            result.AddRange(secondLongest);

            return result;
        }

        private List<int> GetLongest(List<int> subtree)
        {
            var routes = new List<List<int>>();

            if (subtree.Count == 0)
            {
                var children = new List<int>();
                return children;
            }

            foreach (var child in subtree)
            {
                var childPaths = GetLongest(tree[child]);
                childPaths.Add(child);
                routes.Add(childPaths);
            }

            routes.Sort((x, y) => y.Count.CompareTo(x.Count));
            return routes.First();
        }

        public List<List<int>> FindPathsWithSum(int sumToFind)
        {
            var results = FindSum(sumToFind, this.root, new List<List<int>>());
            return results;
        }

        private List<List<int>> FindSum(int sumToFind, int root, List<List<int>> paths)
        {
            foreach (var node in tree[root])
            {
                var sumOfSubtrees = SubTreeSum(node);
                if (sumOfSubtrees == sumToFind)
                {
                    var currentPath = GetPathNodes(node, new List<int>());
                    paths.Add(currentPath);
                }

                if (tree[node] != null)
                {
                    FindSum(sumToFind, node, paths);
                }
            }

            return paths;
        }

        private int SubTreeSum(int root)
        {
            int sum = root;
            foreach (var node in tree[root])
            {
                if (tree[node].Count != 0)
                {
                    sum += SubTreeSum(node);
                }
                else
                {
                    sum += node;
                }
            }

            return sum;
        }

        private List<int> GetPathNodes(int root, List<int> path)
        {
            path.Add(root);
            foreach (var node in tree[root])
            {
                if (tree[node] != null)
                {
                    GetPathNodes(node, path);
                }
            }

            return path;
        }
    }
}
