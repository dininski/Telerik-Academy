namespace Catalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Catalog.Interfaces;
    using Wintellect.PowerCollections;

    public class ContentCatalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public ContentCatalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string old, string newUrl)
        {
            int updatedElements = 0;

            List<IContent> contentToList = this.url[old].ToList();

            foreach (Content content in contentToList)
            {
                this.title.Remove(content.Title, content);
                updatedElements++;
            }

            this.url.Remove(old);

            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
            }

            foreach (IContent content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return updatedElements;
        }

        public List<ICommand> Parse()
        {
            List<ICommand> commandsList = new List<ICommand>();
            bool isEndCommand = false;

            do
            {
                string currentCommand = Console.ReadLine();
                isEndCommand = currentCommand.Trim() == "End";

                if (!isEndCommand)
                {
                    commandsList.Add(new Command(currentCommand));
                }
            }
            while (!isEndCommand);

            return commandsList;
        }
    }
}
