// Write a program that counts how many times each word from
// given text file words.txt appears in it. The character 
// casing differences should be ignored. The result words 
// should be ordered by their number of occurrences in the
// text. Example:
// is -> 2
// the -> 2
// this -> 3
// text -> 6
namespace WordsInTextCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../words.txt");
            Dictionary<string, int> wordOccurences = new Dictionary<string, int>();

            using (sr)
            {
                string currentLine = sr.ReadLine();

                StringBuilder word = new StringBuilder();
                for (int i = 0; i < currentLine.Length; i++)
                {
                    if (currentLine[i] >= 'a' && currentLine[i] <= 'z')
                    {
                        word.Append(currentLine[i]);
                    }
                    else if (currentLine[i] >= 'A' && currentLine[i] <= 'Z')
                    {
                        word.Append((char)(currentLine[i] - 'A' + 'a'));
                    }
                    else
                    {
                        string currentWord = word.ToString();
                        if (currentWord != string.Empty)
                        {
                            if (!wordOccurences.ContainsKey(currentWord))
                            {
                                wordOccurences.Add(currentWord, 0);
                            }

                            wordOccurences[currentWord]++;
                        }

                        word = new StringBuilder();
                    }
                }

                string lastWord = word.ToString();
                if (!string.IsNullOrEmpty(lastWord))
                {
                    if (!wordOccurences.ContainsKey(lastWord))
                    {
                        wordOccurences.Add(lastWord, 0);
                    }

                    wordOccurences[lastWord]++;
                }
            }

            foreach (var word in wordOccurences)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }
    }
}
