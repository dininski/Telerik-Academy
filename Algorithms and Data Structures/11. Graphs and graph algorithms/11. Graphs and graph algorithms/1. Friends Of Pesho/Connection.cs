namespace FriendsInNeed
{
    public class Connection
    {
        public Connection(Node neighbour, int dist)
        {
            this.Node = neighbour;
            this.Distance = dist;
        }

        public Node Node { get; set; }
        public int Distance { get; set; }
    }
}
