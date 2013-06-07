namespace GenericHashedSet
{
    using GenericHashTable;
    using System;
    using System.Collections.Generic;

    public class HashedSet<T>
    {
        public HashedSet()
        {
            this.hashTable = new HashTable<T, int>();
        }

        private readonly HashTable<T, int> hashTable;

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }

        public void Add(T element)
        {
            this.hashTable.Add(element, 0);
        }

        public void Find(T element)
        {
            throw new NotImplementedException();
        }

        public void Remove(T element)
        {
            this.hashTable.Remove(element);
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public IEnumerable<T> Elements()
        {
            return hashTable.Keys();
        }

        public bool Contains(T element)
        {
            return hashTable.ContainsKey(element);
        }

        public void Union(HashedSet<T> setToUnion)
        {
            foreach (var element in setToUnion.Elements())
            {
                if (!this.Contains(element))
                {
                    this.hashTable.Add(element, 0);
                }
            }
        }

        public void Intersect(HashedSet<T> setToIntersect) {
            foreach (var element in setToIntersect.Elements())
            {
                if (!this.Contains(element))
                {
                    this.hashTable.Remove(element);
                }
            }
        }
    }
}
