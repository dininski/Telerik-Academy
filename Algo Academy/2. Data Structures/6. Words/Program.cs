namespace _6.Words
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    public class Program
    {
        public static Dictionary<string, int> wordMatches;
        public static HashSet<string> wordsInSentence;
        public static HashSet<string> usedWords;

        public static void Main(string[] args)
        {
            wordMatches = new Dictionary<string, int>();
            wordsInSentence = new HashSet<string>();
            usedWords = new HashSet<string>();
            StringBuilder result = new StringBuilder();

            int numberOfLines = int.Parse(Console.ReadLine());

#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif

            for (int i = 0; i < numberOfLines; i++)
            {
                string sentence = Console.ReadLine();
                AddWords(sentence);
            }

            int wordsToFindCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < wordsToFindCount; i++)
            {
                string searchedWord = Console.ReadLine();

                if (!wordMatches.ContainsKey(searchedWord))
                {
                    wordMatches.Add(searchedWord, 0);
                }

                if (!usedWords.Contains(searchedWord))
                {
                    usedWords.Add(searchedWord);

                    foreach (var wordInSentence in wordsInSentence)
                    {
                        var sentenceWordLetters = GetLetters(wordInSentence);
                        var searchedLetters = GetLetters(searchedWord);
                        sentenceWordLetters.IntersectWith(searchedLetters);

                        if (sentenceWordLetters.Count == searchedLetters.Count)
                        {
                            wordMatches[searchedWord]++;
                        }
                    }
                }

                result.AppendFormat("{0} -> {1}", searchedWord, wordMatches[searchedWord]);

                if (i < wordsToFindCount - 1)
                {
                    result.AppendLine();
                }
            }

            Console.WriteLine(result.ToString());

#if DEBUG
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
#endif
        }

        public static HashSet<char> GetLetters(string word)
        {
            var letters = new HashSet<char>();
            word = word.ToLower();
            foreach (var letter in word)
            {
                if (!letters.Contains(letter))
                {
                    letters.Add(letter);
                }
            }

            return letters;
        }

        public static void AddWords(string sentence)
        {
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] >= 'a' && sentence[i] <= 'z')
                {
                    word.Append(sentence[i]);
                }
                else if (sentence[i] >= 'A' && sentence[i] <= 'Z')
                {
                    word.Append((char)((int)sentence[i] - (int)'A' + (int)'a'));
                }
                else
                {

                    wordsInSentence.Add(word.ToString());
                    word = new StringBuilder();
                }
            }

            wordsInSentence.Add(word.ToString());
        }
    }
}
