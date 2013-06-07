namespace GenericHashedSet
{
    using GenericHashTable;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HashedSet<T>
    {
        public HashedSet()
        {
            this.hashTable = new HashTable<T, int>();
        }

        private HashTable<T, int> hashTable;

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

        public HashedSet<T> Union(HashedSet<T> setToUnion)
        {
            throw new NotImplementedException();
        }

        public HashedSet<T> Intersect(HashedSet<T> setToUnion) {
            throw new NotImplementedException();
        }
    }
}
