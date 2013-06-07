namespace GenericHashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K,V>>
    {
        private LinkedList<KeyValuePair<K, V>>[] buckets;
        private int size;
        private const double MaxLoad = 0.75;

        public HashTable()
        {
            this.size = 16;
            this.buckets = new LinkedList<KeyValuePair<K, V>>[size];
        }

        public int Count { get; private set; }

        public V this[K key]
        {
            get
            {
                int bucketHash = key.GetHashCode() % size;

                if (this.buckets[bucketHash] == null)
                {
                    throw new ArgumentException("No element found with the provided key.");
                }

                foreach (var bucketElement in this.buckets[bucketHash])
                {
                    if (bucketElement.Key.Equals(key))
                    {
                        return bucketElement.Value;
                    }
                }

                throw new ArgumentException("No element found with the provided key.");
            }

            set
            {
                int bucketHash = key.GetHashCode() % size;
                KeyValuePair<K, V> pairToChange = this.buckets[bucketHash].Where(x => x.Key.Equals(key)).First();
                this.buckets[bucketHash].Remove(pairToChange);
                KeyValuePair<K, V> updatedPair = new KeyValuePair<K, V>(key, value);
                this.buckets[bucketHash].AddLast(updatedPair);
            }
        }

        public void Add(K key, V value)
        {
            this.Count++;

            int bucketHash = key.GetHashCode() % size;

            if (this.ContainsKey(key))
            {
                throw new ArgumentException("A key with the value " + key + " already exists in the hash table.");
            }

            KeyValuePair<K, V> newElement = new KeyValuePair<K, V>(key, value);

            this.buckets[bucketHash].AddLast(newElement);

            if (this.buckets[bucketHash].Count / this.size >= MaxLoad)
            {
                this.Resize();
            }
        }

        public bool ContainsKey(K key)
        {
            int bucketHash = key.GetHashCode() % size;

            if (this.buckets[bucketHash] == null)
            {
                this.buckets[bucketHash] = new LinkedList<KeyValuePair<K, V>>();
            }

            return this.buckets[bucketHash].Where(x => x.Key.Equals(key)).Count() != 0;
        }

        public V Find(K key)
        {
            return this[key];
        }

        public void Remove(K key)
        {
            this.Count--;

            int bucketHash = key.GetHashCode() % size;

            var keyValuePairToRemoveBucket = this.buckets[bucketHash].Where(x => x.Key.Equals(key));

            if (keyValuePairToRemoveBucket.Count() != 0)
            {
                this.buckets[bucketHash].Remove(keyValuePairToRemoveBucket.First());
            }
        }

        public void Clear()
        {
            this.buckets = new LinkedList<KeyValuePair<K, V>>[this.size];
            this.Count = 0;
        }

        public K[] Keys()
        {
            var allKeys = new List<K>();

            foreach (var bucket in this.buckets)
            {
                if (bucket != null)
                {
                    foreach (var kvPair in bucket)
                    {
                        allKeys.Add(kvPair.Key);
                    }
                }
            }

            return allKeys.ToArray();
        }

        private void Resize()
        {

            // resizing the array to 2 times - 1, because if we only multiply
            // it by 2 we will get some of the same elements in the same bucket
            // again. e.g. size1 = 16, size2 = 32:
            // element1 has hashCode = 32, element2 has hashCode = 64
            // element1 hashCode % size1 = 0 ( 32 % 16 = 0 ) and 
            // element2 hashCode % size1 = 0 ( 64 % 16 = 0 ) => both elements are in
            // the same bucket.
            // If we use size2 = 31 (2 * size1 - 1 ) both elements will be in
            // different buckets: 
            // element1 hashCode 32 % 31 = 1 -> bucket at position 1
            // element2 hashCode 64 % 31 = 2 -> bucket at position 2

            size *= 2 - 1;

            var newBuckets = new LinkedList<KeyValuePair<K, V>>[size];

            foreach (var bucket in this.buckets)
            {
                if (bucket != null)
                {
                    foreach (var element in bucket)
                    {
                        var bucketHash = element.Key.GetHashCode() % size;

                        if (newBuckets[bucketHash] == null)
                        {
                            newBuckets[bucketHash] = new LinkedList<KeyValuePair<K, V>>();
                        }

                        newBuckets[bucketHash].AddLast(element);
                    }
                }
            }

            this.buckets = newBuckets;
        }

        public IEnumerator GetEnumerator()
        {
            return new HashTableEnumerator(this);
        }

        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            return new HashTableEnumerator(this);
        }

        private class HashTableEnumerator : IEnumerator<KeyValuePair<K, V>>
        {
            private readonly KeyValuePair<K, V>[] allElements;
            private int position = -1;

            public HashTableEnumerator(HashTable<K, V> hashTable)
            {
                var tableKeys = hashTable.Keys();
                allElements = new KeyValuePair<K, V>[hashTable.Count];

                for (int i = 0; i < tableKeys.Length; i++)
                {
                    allElements[i] = new KeyValuePair<K, V>(tableKeys[i], hashTable[tableKeys[i]]);
                }
            }

            public KeyValuePair<K, V> Current
            {
                get
                {
                    try
                    {
                        return this.allElements[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public bool MoveNext()
            {
                position++;
                return position < allElements.Length;
            }

            public void Reset()
            {
                this.position = -1;
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }
        }
    }
}
