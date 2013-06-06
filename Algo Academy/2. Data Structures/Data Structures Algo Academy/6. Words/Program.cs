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

                AddWords(sentence);
            }

            int wordsToFindCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < wordsToFindCount; i++)
            {
                string word = Console.ReadLine();
                allWords.Add(word);


                if (!wordsThatMatch.ContainsKey(word))
                {
                    wordsThatMatch.Add(word, 0);
                }
            }


            foreach (var searchedWord in allWords)
            {
                foreach (var sentenceWord in wordsInSentence)
                {
                    var sentenceWordLetters = GetLetters(sentenceWord);
                    var searchedLetters = GetLetters(searchedWord);
                    
                    sentenceWordLetters.IntersectWith(searchedLetters);
                    
                    if (sentenceWordLetters.Count == searchedLetters.Count)
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

        public static void AddWords(string sentence)
        {
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] >= 'a' && sentence[i] <= 'z' || sentence[i] >= 'A' && sentence[i] <= 'Z')
                {
                    word.Append(sentence[i]);
                }
                else
                {
                    if (word.ToString() != "")
                    {
                        wordsInSentence.Add(word.ToString().ToLower());
                    }

                    word = new StringBuilder();
                }
            }

            wordsInSentence.Add(word.ToString().ToLower());
        }
    }
}
