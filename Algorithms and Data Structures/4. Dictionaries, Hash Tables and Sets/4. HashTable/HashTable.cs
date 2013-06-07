namespace GenericHashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V>
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

            if (this.Count / this.size >= MaxLoad)
            {
                this.Resize();
            }

            KeyValuePair<K, V> newElement = new KeyValuePair<K, V>(key, value);
            int bucketHash = key.GetHashCode() % size;

            if (this.buckets[bucketHash] == null)
            {
                this.buckets[bucketHash] = new LinkedList<KeyValuePair<K, V>>();
            }

            if (this.buckets[bucketHash].Select(x => x.Key.Equals(key)).Count() != 0)
            {
                throw new ArgumentException("A key with that value already exists in the hash table.");
            }

            this.buckets[bucketHash].AddLast(newElement);
        }

        public V Find(K key)
        {
            return this[key];
        }

        public void Remove(K key)
        {
            this.Count--;
            int bucketHash = key.GetHashCode() % size;

            KeyValuePair<K, V> keyValuePairToRemove = this.buckets[bucketHash].Where(x => x.Key.Equals(key)).First();

            this.buckets[bucketHash].Remove(keyValuePairToRemove);
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
            size *= 2;

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
    }
}
