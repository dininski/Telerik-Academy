namespace _6.Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static Dictionary<string, int> wordsThatMatch;
        public static HashSet<string> wordsInSentence;
        public static HashSet<string> allWords;

        public static void Main(string[] args)
        {
            allWords = new HashSet<string>();
            wordsThatMatch = new Dictionary<string, int>();
            wordsInSentence = new HashSet<string>();
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLines; i++)
            {
                string sentence = Console.ReadLine();
                
                string[] words = ParseWords(sentence);

                foreach (var word in words)
                {
                    if (!wordsInSentence.Contains(word))
                    {
                        wordsInSentence.Add(word);
                    }
                }
            }

            int wordsToFindCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < wordsToFindCount; i++)
            {
                string word = Console.ReadLine();
                if (!allWords.Contains(word))
                {
                    allWords.Add(word);
                }

                if (!wordsThatMatch.ContainsKey(word))
                {
                    wordsThatMatch.Add(word, 0);
                }
            }

            foreach (var word in wordsInSentence)
            {
                foreach (var searchedWord in allWords)
                {
                    var lettersInWord = GetLetters(word);
                    var searchedLetters = GetLetters(searchedWord);
                    searchedLetters.IntersectWith(lettersInWord);

                    if (searchedLetters.Count == searchedWord.Length)
                    {
                        wordsThatMatch[searchedWord]++;
                    }
                }
            }

            PrintDict(wordsThatMatch);
        }

        public static void PrintHashSet(HashSet<string> words)
        {
            foreach (var word in words)
            {
                Console.Write("{0}, ", word);
            }
        }

        public static void PrintDict(Dictionary<string, int> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
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

        public static string[] ParseWords(string sentence)
        {
            List<string> words = new List<string>();
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < sentence.Length; i++)
            {
                if ((sentence[i] >= 'a' && sentence[i] <= 'z') || (sentence[i] >= 'A' && sentence[i] <= 'Z'))
                {
                    word.Append(sentence[i]);       
                }
                else
                {
                    if (word.ToString() != "")
                    {
                        words.Add(word.ToString());
                    }

                    word = new StringBuilder();
                }
            }

            return words.ToArray();
        }
    }
}
