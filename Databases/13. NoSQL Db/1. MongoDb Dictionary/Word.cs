namespace MongoDbDictionary
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;

    public class Word
    {
        public Word(string text, string explanation)
        {
            this.Text = text;
            this.Explanation = explanation;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Text { get; set; }

        public string Explanation { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Text, this.Explanation);
        }
    }
}
