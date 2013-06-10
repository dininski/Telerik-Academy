namespace TreeTraversal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            Tree tree = new Tree();

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                string input = Console.ReadLine();
                string[] inputNummbersAsString = input.Split(' ');
                int parent = int.Parse(inputNummbersAsString[0]);
                int child = int.Parse(inputNummbersAsString[1]);
                tree.AddNode(parent, child);
            }

            // 1. find root:
            Console.WriteLine("The root of the tree is: {0}", tree.GetRoot());
            
            // 2. find middle elements:
            Console.WriteLine("The middle elements of the tree are: {0}", tree.GetMiddleElementsAsString());
            
            // 3. find leafs:
            Console.WriteLine("The leafs in the tree are: {0}", tree.GetLeafsAsString());

            // 4. find longest route:
            var longestRoute = tree.FindLongestRoute();
            Console.Write("The longest route is: ");
            foreach (var element in longestRoute)
            {
                Console.Write("{0}, ", element);
            }
            Console.WriteLine();

            // 5. All paths in the tree with given sum of their nodes
            // NOTE: bug - adding 0 length paths more than once.
            Console.WriteLine("Paths with sum, entered by the user.");
            Console.Write("Please enter a sum to find: ");
            int pathSumToFind = int.Parse(Console.ReadLine());
            var paths = tree.FindPathsWithSum(pathSumToFind);
            Console.WriteLine("Paths with sum: {0}", pathSumToFind);
            foreach (var path in paths)
            {
                foreach (var node in path)
                {
                    Console.Write("{0} ", node);
                }
                Console.WriteLine();
            }

            // 6. Subtrees with sum entered by the user
            Console.WriteLine("Subtrees with a sum, entered by the user.");
            Console.Write("Please enter a sum to find: ");
            int subtreeSumToFind = int.Parse(Console.ReadLine());
            var subtrees = tree.FindSubtreesWithSum(subtreeSumToFind);
            Console.WriteLine("Subtrees with sum {0}:", subtreeSumToFind);
            foreach (var subtree in subtrees)
            {
                foreach (var node in subtree)
                {
                    Console.Write("{0} ", node);
                }

                Console.WriteLine();
            }
        }
    }
}
