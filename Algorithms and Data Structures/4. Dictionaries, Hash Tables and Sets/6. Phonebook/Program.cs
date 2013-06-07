namespace _6.Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main(string[] args)
        {
            StreamReader phones = new StreamReader("..\\..\\phones.txt");

            var phonebook = new MultiDictionary<string, MultiDictionary<string, string>>(false);
            using (phones)
            {
                while (!phones.EndOfStream)
                {
                    string entry = phones.ReadLine();
                    string[] entryInfo = entry.Split('|');
                    string name = entryInfo[0].Trim();
                    string location = entryInfo[1].Trim();
                    string phoneNumber = entryInfo[2].Trim();

                    if (phonebook.ContainsKey(name))
                    {
                        var nameInPhoneBook = phonebook[name].First();
                        if (nameInPhoneBook.ContainsKey(location))
                        {
                            nameInPhoneBook[location].Add(phoneNumber);
                        }
                        else
                        {
                            nameInPhoneBook.Add(location, phoneNumber);
                        }
                    }
                    else
                    {
                        phonebook.Add(name, new MultiDictionary<string, string>(true));
                        var nameInPhoneBook = phonebook[name].First();
                        nameInPhoneBook.Add(location, phoneNumber);
                    }
                }
            }

            var commands = new StreamReader("..\\..\\commands.txt");
            using (commands)
            {
                while (!commands.EndOfStream)
                {
                    string commandString = commands.ReadLine();
                    string[] parameters = commandString
                        .Substring(commandString.IndexOf('(') + 1, commandString.IndexOf(')') - commandString.IndexOf('(') - 1)
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = parameters[0].Trim();
                    string location = string.Empty;

                    if (parameters.Length == 2)
                    {
                        location = parameters[1].Trim();
                    }

                    Console.WriteLine(commandString);

                    if (location == string.Empty)
                    {
                        var resultsByName = phonebook.Where(x => x.Key == name);
                        foreach (var nameEntries in resultsByName)
                        {
                            foreach (var locationPhoneCollection in nameEntries.Value)
                            {
                                foreach (var phonesCollection in locationPhoneCollection)
                                {
                                    foreach (var phoneNumber in phonesCollection.Value)
                                    {
                                        Console.WriteLine("{0} -> {1} -> {2}",
                                            nameEntries.Key, phonesCollection.Key, phoneNumber);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var resultsByName = phonebook.Where(x => x.Key == name);

                        foreach (var nameEntries in resultsByName)
                        {
                            foreach (var locationPhoneCollection in nameEntries.Value)
                            {
                                var nameAndLocation = locationPhoneCollection.Where(x => x.Key == location);

                                foreach (var phonesCollection in nameAndLocation)
                                {
                                    foreach (var phoneNumber in phonesCollection.Value)
                                    {
                                        Console.WriteLine("{0} -> {1} -> {2}", nameEntries.Key, phonesCollection.Key, phoneNumber);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
