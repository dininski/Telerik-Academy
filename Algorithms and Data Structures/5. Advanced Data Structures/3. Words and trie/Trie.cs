using System.Collections.Generic;
namespace WordsAndTrie
{
    public class Trie<T> where T:class
    {
        private readonly TrieNode<T> root;

        public Trie () {
            this.root = TrieNode<T>.GetEmptyNode();          
        }

        public TrieNode<T> Find(TrieNode<T> startNode, string value)
        {
            TrieNode<T> current = startNode;
            foreach (char c in value.ToCharArray())
            {
                if (current.ContainsChild(c))
                {
                    current = current.GetChild(c);
                }
                else
                {
                    current = TrieNode<T>.GetEmptyNode();
                    break;
                }
            }

            return current;
        }

        public void Put(string key, T value)
        {
            TrieNode<T> node = root;
            foreach (char c in key)
            {
                node = node.AddChild(c);
            }

            node.Value = value;
        }

        public void Remove(string key)
        {
            TrieNode<T> node = root;

            foreach (char c in key)
            {
                node.RemoveChild(c);
            }

            node.Value = null;

            while (node != root && !node.IsTerminater() && node.ChildrenCount() != 0)
            {
                char prevKey = node.Key;
                node = node.Parent;
                node.RemoveChild(prevKey);
            }


        }
    }
}
