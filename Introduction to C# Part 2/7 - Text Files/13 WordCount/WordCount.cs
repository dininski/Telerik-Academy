using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        try
        {
            string pathToWords = "../../words.txt";
            string pathToText = "../../textFile.txt";
            StreamReader reader = new StreamReader(pathToWords);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string currentWord = reader.ReadLine();
                    if (dict.ContainsKey(currentWord))
                    {
                        dict[currentWord]++;
                    }
                    else
                    {
                        dict.Add(currentWord, 0);
                    }
                }
            }

            reader = new StreamReader(pathToText);
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] words = line.Split('.', ' ', '!', '"', '!', ',', '(', ')');
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (dict.ContainsKey(words[i]))
                        {
                            dict[words[i]]++;
                        }
                    }
                }
            }

            List<KeyValuePair<string, int>> asList = dict.ToList();

            asList.Sort((FirstPair, NextPair) =>
            {
                return FirstPair.Value.CompareTo(NextPair.Value);
            });

            foreach (var item in asList)
            {
                Console.WriteLine(item);
            }


        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Path is null");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found");
        }
        catch (IOException)
        {
            Console.WriteLine("IO exception");
        }

    }
}
