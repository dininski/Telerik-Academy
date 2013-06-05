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

            Console.WriteLine("The root of the tree is: {0}", tree.GetRoot());
            Console.WriteLine("The middle elements of tree are: {0}", tree.GetMiddleElementsAsString());
            Console.WriteLine("The leafs in the tree are: {0}", tree.GetLeafsAsString());

            var test = tree.FindLongestRoute();

            Console.Write("The longest route is: ");
            foreach (var element in test)
            {
                Console.Write("{0}, ", element.Value);
            }
        }
    }
}
