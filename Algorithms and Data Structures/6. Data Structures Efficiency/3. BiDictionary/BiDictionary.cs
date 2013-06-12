using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionaryProblem
{
    public class BiDictionary<K1, K2, T>
    {
        Dictionary<K1, Tuple<K2, T>> firstKeyElements;
        Dictionary<K2, Tuple<K1, T>> secondKeyElements;
        Dictionary<Tuple<K1, K2>, T> thirdKeyElements;

        public BiDictionary()
        {
            this.firstKeyElements = new Dictionary<K1, Tuple<K2, T>>();
            this.secondKeyElements = new Dictionary<K2, Tuple<K1, T>>();
            this.thirdKeyElements = new Dictionary<Tuple<K1, K2>, T>();
        }

        public void AddElement(K1 firstKey, K2 secondKey, T value)
        {
            this.firstKeyElements.Add(firstKey, new Tuple<K2, T>(secondKey, value));
            this.secondKeyElements.Add(secondKey, new Tuple<K1, T>(firstKey, value));
            this.thirdKeyElements.Add(new Tuple<K1, K2>(firstKey, secondKey), value);
        }

        public T GetElementByFirstKey(K1 key)
        {
            return firstKeyElements[key].Item2;
        }

        public T GetElementBySecondKey(K2 key)
        {
            return secondKeyElements[key].Item2;
        }

        public T GetElementByTwoKeys(K1 first, K2 second)
        {
            var element = new Tuple<K1, K2>(first, second);
            return thirdKeyElements[element];
        }
    }
}
