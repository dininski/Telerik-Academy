namespace Minimum_Spanning_Tree_Prim
{
    using System;
    
    public class Node : IComparable
    {
        public Node(int val)
        {
            this.Value = val;
            this.Used = false;
        }

        public int Value { get; set; }

        public int CompareTo(object obj)
        {
            return this.Value.CompareTo((obj as Node).Value);
        }

        public bool Used { get; set; }
    }
}
