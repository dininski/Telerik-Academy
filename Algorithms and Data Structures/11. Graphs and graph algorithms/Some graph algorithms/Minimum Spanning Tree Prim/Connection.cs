namespace Minimum_Spanning_Tree_Prim
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Connection : IComparable
    {
        public Connection(Node to, int dist)
        {
            this.ToNode = to;
            this.Distance = dist;
        }

        public Node ToNode { get; set; }

        public int Distance { get; set; }

        public int CompareTo(object obj)
        {
            return this.Distance.CompareTo((obj as Connection).Distance);
        }
    }
}