namespace FriendsInNeed
{
    using Wintellect.PowerCollections;
    using System.Linq;

    public class PriorityQueue
    {
        OrderedBag<Node> elements;

        public PriorityQueue()
        {
            this.elements = new OrderedBag<Node>();
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Enqueue(Node newNode)
        {
            this.elements.Add(newNode);
        }

        public Node Dequeue()
        {
            var nodeToReturn = this.elements.GetFirst();
            this.elements.RemoveFirst();
            return nodeToReturn;
        }

        public Node Peek()
        {
            return this.elements.First();
        }
    }
}
