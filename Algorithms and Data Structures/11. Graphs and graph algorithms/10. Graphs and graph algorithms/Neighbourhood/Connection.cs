namespace Minimum_Spanning_Tree_Prim
{
    using System;

    public class Connection : IComparable
    {
        public Connection(Node to, int dist)
        {
            this.ToNode = to;
            this.Distance = dist;
        }

        public Node ToNode { get; set; }

        public Node FromNode { get; set; }

        public int Distance { get; set; }

        public int CompareTo(object obj)
        {
            return this.Distance.CompareTo((obj as Connection).Distance);
        }
    }
}