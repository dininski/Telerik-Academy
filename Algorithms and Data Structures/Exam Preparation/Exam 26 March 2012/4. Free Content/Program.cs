namespace FreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            string commandString = Console.ReadLine();
            Command currentCommand = Command.Parse(commandString);
            ContentManager cm = new ContentManager();
            StringBuilder result = new StringBuilder();

            while (currentCommand.Type != "End")
            {
                Item item;

                switch (currentCommand.Type)
                {
                    case "Add book":
                        item = new Item(currentCommand.Arguments[0].Trim(), currentCommand.Arguments[1].Trim(),
                            currentCommand.Arguments[2].Trim(), currentCommand.Arguments[3].Trim(), "Book");
                        result.AppendLine(cm.AddItem(item));
                        break;
                    case "Add movie":
                        item = new Item(currentCommand.Arguments[0].Trim(), currentCommand.Arguments[1].Trim(),
                            currentCommand.Arguments[2].Trim(), currentCommand.Arguments[3].Trim(), "Movie");
                        result.AppendLine(cm.AddItem(item));
                        break;
                    case "Add song":
                        item = new Item(currentCommand.Arguments[0].Trim(), currentCommand.Arguments[1].Trim(),
                            currentCommand.Arguments[2].Trim(), currentCommand.Arguments[3].Trim(), "Song");
                        result.AppendLine(cm.AddItem(item));
                        break;
                    case "Add application":
                        item = new Item(currentCommand.Arguments[0].Trim(), currentCommand.Arguments[1].Trim(),
                            currentCommand.Arguments[2].Trim(), currentCommand.Arguments[3].Trim(), "Application");
                        result.AppendLine(cm.AddItem(item));
                        break;
                    case "Update":
                        string oldUrl = currentCommand.Arguments[0].Trim();
                        string newUrl = currentCommand.Arguments[1].Trim();
                        result.AppendLine(cm.UpdateItem(oldUrl, newUrl));
                        break;
                    case "Find":
                        string searchTerms = currentCommand.Arguments[0].Trim();
                        int count = int.Parse(currentCommand.Arguments[1].Trim());
                        result.Append(cm.FindItems(searchTerms, count));
                        break;
                    default:
                        break;
                }

                currentCommand = Command.Parse(Console.ReadLine());
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    public class Item :IComparable<Item>
    {
        public Item(string title, string author, string size, string url, string type)
        {
            this.Title = title;
            this.Author = author;
            this.Size = size;
            this.Url = url;
            this.Type = type;

            switch (type[0])
            {
                case 'B':
                    this.compareWeight = 1;
                    break;
                case 'M':
                    this.compareWeight = 10;
                    break;
                case 'S':
                    this.compareWeight = 100;
                    break;
                case 'A':
                    this.compareWeight = 1000;
                    break;
            }

            this.TextPresentation = string.Format("{0}; {1}; {2}; {3}", this.Title, this.Author, this.Size, this.Url);
        }

        private int compareWeight;

        public string TextPresentation;

        public string Title { get; set; }

        public string Author { get; set; }

        public string Size { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Type, this.TextPresentation);
        }

        public int CompareTo(Item other)
        {
            int typeComparison = this.compareWeight.CompareTo(other.compareWeight);

            if (typeComparison == 0)
            {
                this.TextPresentation.CompareTo(other.TextPresentation);
            }

            return typeComparison;
        }
    }

    public class Command
    {
        public Command(string type, string[] args)
        {
            this.Type = type;
            this.Arguments = args;
        }

        public string Type { get; set; }

        public string[] Arguments { get; set; }

        public static Command Parse(string input)
        {
            int commandSeparator = input.IndexOf(':');
            string[] args = new string[1];
            string command = input;

            if (commandSeparator > 0)
            {
                command = input.Substring(0, commandSeparator);
                args = input.Substring(commandSeparator + 1).Split(';');
            }

            return new Command(command, args);
        }
    }

    public class ContentManager
    {
        OrderedMultiDictionary<string, Item> itemsByTitle;
        MultiDictionary<string, Item> itemsByUrl;

        public ContentManager()
        {
            this.itemsByTitle = new OrderedMultiDictionary<string, Item>(true);
            this.itemsByUrl = new MultiDictionary<string, Item>(true);
        }

        public string AddItem(Item newitem)
        {
            itemsByTitle.Add(newitem.Title, newitem);
            itemsByUrl.Add(newitem.Url, newitem);
            return string.Format("{0} added", newitem.Type);
        }

        public string UpdateItem(string oldUrl, string newUrl)
        {
            if (!itemsByUrl.ContainsKey(oldUrl))
            {
                return "0 items updated";
            }
            else
            {
                IEnumerable<Item> itemsToUpdate = new List<Item>(itemsByUrl[oldUrl]);
                int updateCount = itemsToUpdate.Count();
                
                foreach (var item in itemsToUpdate)
                {
                    var newItem = new Item(item.Title, item.Author, item.Size, newUrl, item.Type);
                    itemsByUrl.Add(newUrl, newItem);
                    itemsByTitle.Remove(item.Title, item);
                    itemsByTitle.Add(item.Title, newItem);
                }

                itemsByUrl.Remove(oldUrl);

                return string.Format("{0} items updated", updateCount);
            }
        }

        public string FindItems(string searchString, int count)
        {
            if (!itemsByTitle.ContainsKey(searchString))
            {
                return "No items found\r\n";
            }
            else
            {
                var itemsToReturn = itemsByTitle[searchString].Take(count);
                StringBuilder result = new StringBuilder();

                foreach (var item in itemsToReturn)
                {
                    result.AppendLine(item.ToString());
                }

                return result.ToString();
            }
        }
    }
}
