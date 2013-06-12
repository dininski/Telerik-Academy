using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionaryProblem
{
    public class BiDictionary<K1, K2, T>
    {
        Dictionary<K1, T> firstKeyElements;
        Dictionary<K2, T> secondKeyElements;
        Dictionary<KeyValuePair<K1, K2>, T> thirdKeyElements;

        public BiDictionary()
        {
            this.firstKeyElements = new Dictionary<K1, T>();
            this.secondKeyElements = new Dictionary<K2,T>();
            this.thirdKeyElements = new Dictionary<KeyValuePair<K1, K2>, T>();
        }

        public void AddElement(K1 firstKey, K2 secondKey, T value)
        {
            this.firstKeyElements.Add(firstKey, value);
            this.secondKeyElements.Add(secondKey, value);
            this.thirdKeyElements.Add(new KeyValuePair<K1, K2>(firstKey, secondKey), value);
        }

        public T GetElementByFirstKey(K1 key)
        {
            return firstKeyElements[key];
        }

        public T GetElementBySecondKey(K2 key)
        {
            return secondKeyElements[key];
        }

        public T GetElementByTwoKeys(K1 first, K2 second)
        {
            var element = new KeyValuePair<K1, K2>(first, second);
            return thirdKeyElements[element];
        }
    }
}
