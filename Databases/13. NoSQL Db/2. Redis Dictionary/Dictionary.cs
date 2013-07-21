namespace RedisDictionary
{
    using ServiceStack.Redis;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Dictionary : IEnumerable
    {
        private RedisClient client;
        private string dictName;

        public Dictionary(RedisClient client, string dictName)
        {
            this.client = client;
            this.dictName = dictName;
        }

        public bool Add(string word, string explanation)
        {
            if (this.ContainsWord(word))
            {
                return false;
            }
            else
            {
                this.client.HSet(this.dictName, word.ToAsciiCharArray(), explanation.ToAsciiCharArray());
                return true;
            }
        }

        public bool Remove(string word)
        {
            if (this.ContainsWord(word))
            {
                this.client.HDel(this.dictName, word.ToAsciiCharArray());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsWord(string word)
        {
            if (this.client.HExists(this.dictName, word.ToAsciiCharArray()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            var allWords = this.client.HGetAll(this.dictName);

            for (int i = 0; i < allWords.Length; i += 2)
            {
                yield return string.Format("{0} - {1}",
                    allWords[i].StringFromByteArray(), allWords[i + 1].StringFromByteArray());
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
