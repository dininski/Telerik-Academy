namespace WordsAndTrie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TrieNode<T> where T : class
    {
        private readonly Dictionary<char, TrieNode<T>> children;

        public T Value { get; set; }

        public char Key { get; set; }

        public TrieNode<T> Parent { get; set; }

        public TrieNode(TrieNode<T> parent, char key)
        {
            this.Key = key;
            this.Value = null;
            this.Parent = parent;
            this.children = new Dictionary<char, TrieNode<T>>();
        }

        public static TrieNode<T> GetEmptyNode()
        {
            TrieNode<T> empty = new TrieNode<T>(null, '\0');
            return empty;
        }

        public bool ContainsChild(char c)
        {
            return this.children.ContainsKey(c);
        }

        public TrieNode<T> GetChild(char c)
        {
            if (this.children.ContainsKey(c))
            {
                return this.children[c];
            }

            return null;
        }

        public int ChildrenCount()
        {
            return this.children.Count;
        }

        public TrieNode<T> AddChild(char key)
        {
            if (this.children.ContainsKey(key))
            {
                return this.children[key];
            }
            else
            {
                TrieNode<T> child = new TrieNode<T>(this, key);
                this.children.Add(key, child);
                return child;
            }
        }

        public void RemoveChild(char key)
        {
            this.children.Remove(key);
        }

        public bool IsLeaf()
        {
            return this.ChildrenCount() == 0;
        }

        public bool IsTerminater()
        {
            return this.Value == null;
        }

        public IEnumerable<T> PrefixMatches()
        {
            if (this.IsLeaf())
            {
                if (this.IsTerminater())
                {
                    return new List<T>(new T[] { this.Value });
                }
                else
                {
                    return new List<T>();
                }
            }
            else
            {
                var values = new List<T>();

                foreach (TrieNode<T> child in this.children)
                {
                    values.AddRange(child.PrefixMatches());    
                }

                if (this.IsTerminater())
                {
                    values.Add(this.Value);
                }

                return values;
            }
        }
    }
}
