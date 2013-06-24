namespace Minimum_Spanning_Tree_Prim
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class PriorityQueue
    {
        OrderedBag<Connection> elements;

        public PriorityQueue()
        {
            this.elements = new OrderedBag<Connection>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Enqueue(Connection connection)
        {
            this.elements.Add(connection);
        }

        public Connection Dequeue()
        {
            var first = this.elements.GetFirst();
            this.elements.RemoveFirst();
            return first;
        }

        public Connection Peek()
        {
            return this.elements.GetFirst();
        }
    }
}
