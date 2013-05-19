namespace Catalog
{
    using System;
    using Catalog.Enumerations;
    using Catalog.Interfaces;

    public class Content : IComparable, IContent
    {
        private string url;

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentInformation.Title];
            this.Author = commandParams[(int)ContentInformation.Author];
            this.Size = long.Parse(commandParams[(int)ContentInformation.Size]);
            this.URL = commandParams[(int)ContentInformation.Url];
        }
        
        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string URL
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Cannot compare to a null object");
            }

            Content otherContent = obj as Content;

            if (otherContent != null)
            {
                int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResult;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
