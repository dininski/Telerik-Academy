namespace RedisDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ServiceStack.Redis;

    public class Program
    {
        static void Main()
        {
            using (RedisClient client = new RedisClient())
            {
                string dictString = "Dictionary";
                Dictionary dict = new Dictionary(client, dictString);
                Console.WriteLine("Welcome to Redis Dictionary");

                string userCommand = "";
                while (userCommand != "exit")
                {
                    Console.WriteLine("Enter 'add' to enter new word");
                    Console.WriteLine("Enter 'show' to display all entries");
                    Console.WriteLine("Enter 'remove' to remove  word");
                    Console.WriteLine("Enter 'exit' to exit");

                    userCommand = Console.ReadLine();

                    switch (userCommand)
                    {
                        case "add":
                            AddCommand(dict);
                            break;
                        case "show":
                            DisplayCommand(dict);
                            break;
                        case "remove":
                            RemoveCommand(dict);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void DisplayCommand(Dictionary dict)
        {
            foreach (var word in dict)
            {
                Console.WriteLine(word);
            }
        }

        private static void AddCommand(Dictionary dict)
        {
            Console.WriteLine("Please enter the word:");
            var word = Console.ReadLine();
            Console.WriteLine("Please enter the explanation:");
            var explanation = Console.ReadLine();
            var addResult = dict.Add(word, explanation);

            if (addResult)
            {
                Console.WriteLine("Successfully added!");
            }
            else
            {
                Console.WriteLine("This word already exists in the dictionary.");
            }
        }

        private static void RemoveCommand(Dictionary dict)
        {
            Console.WriteLine("Please enter the word to remove:");
            var word = Console.ReadLine();

            var removeResult = dict.Remove(word);

            if (removeResult)
            {
                Console.WriteLine("Removed the word.");
            }
            else
            {
                Console.WriteLine("Word not found in the dictionary.");
            }
        }
    }
}
