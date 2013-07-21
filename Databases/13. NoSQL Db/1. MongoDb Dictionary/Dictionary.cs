namespace MongoDbDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using MongoDB.Driver.Builders;
    using System.Collections;

    public class Dictionary : IEnumerable
    {
        private MongoCollection<Word> dict;
        private IQueryable<Word> queryableCollection;

        public Dictionary(MongoCollection<Word> dictionary)
        {
            this.dict = dictionary;
            this.queryableCollection = dictionary.AsQueryable<Word>();
        }

        public bool Add(string word, string explanation)
        {
            if (this.ContainsWord(word))
            {
                return false;
            }
            else
            {
                this.dict.Insert<Word>(new Word(word, explanation));
                return true;
            }
        }

        public bool Remove(string word)
        {
            if (this.ContainsWord(word))
            {
                var toRemove = Query.EQ("Text", word);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsWord(string word)
        {
            return this.queryableCollection.Where(w => w.Text == word).Any();
        }

        public IEnumerator<string> GetEnumerator()
        {
            var allWords = this.queryableCollection.ToList();

            foreach (var word in allWords)
            {
                yield return String.Format("{0} - {1}", word.Text, word.Explanation);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
