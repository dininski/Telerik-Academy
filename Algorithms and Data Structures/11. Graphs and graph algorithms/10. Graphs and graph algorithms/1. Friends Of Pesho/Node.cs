namespace FriendsInNeed
{
    using System;

    public class Node : IComparable<Node>
    {
        public Node(int val)
        {
            this.Value = val;
        }

        public bool IsHospital { get; set; }

        public int Value { get; set; }

        public int DijkstraDistance { get; set; }

        public int CompareTo(Node other)
        {
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }

        public override bool Equals(object obj)
        {
            return this.Value == (obj as Node).Value;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
