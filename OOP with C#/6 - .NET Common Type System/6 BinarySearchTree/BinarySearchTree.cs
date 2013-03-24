using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BST<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, ICloneable where TKey : IComparable<TKey>
    {
        private TreeNode root = null;

        private class TreeNode
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public TreeNode Previous { get; set; }
            public TreeNode Next { get; set; }
            public TreeNode Parent { get; set; }

        }

        public void Add(TKey key, TValue value)
        {
            TreeNode node = new TreeNode();
            node.Key = key;
            node.Value = value;

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            //TODO
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            //TODO
            throw new NotImplementedException();
        }

        public object Clone()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
