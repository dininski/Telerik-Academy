namespace _8_Feb___Crossword
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static int wordsCount;
        static string[] words;
        static bool[] used;

        static void Main(string[] args)
        {
            wordsCount = int.Parse(Console.ReadLine());
            words = new string[wordsCount * 2];
            used = new bool[wordsCount * 2];

            for (int i = 0; i < wordsCount * 2; i++)
            {
                words[i] = Console.ReadLine();
            }

            Array.Sort(words);

            for (int i = 0; i < wordsCount * 2; i++)
            {
                var result = GenerateCrossword(new string[wordsCount], words[i], 0);

                Console.WriteLine();

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }

            }

            Console.WriteLine("NO SOLUTION!");
        }

        public static string[] GenerateCrossword(string[] result, string currentWord, int currentPos)
        {
            if (currentPos == wordsCount)
            {
                return result;
            }
            result[currentPos] = currentWord;

            used[currentPos] = true;

            string[] res = new string[1];

            for (int i = currentPos + 1; i < words.Length; i++)
            {
                if (!used[i])
                {
                    res = GenerateCrossword(result, words[i], currentPos + 1);
                }
                used[currentPos] = false;
                return res;
            }


            return res;
        }

        public static bool CheckIfSolution(string[] result)
        {
            for (int i = 0; i < wordsCount; i++)
            {
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < wordsCount; j++)
                {
                    sb.Append(result[j][i]);
                }

                if (!words.Contains(sb.ToString()))
                {
                    return false;
                }

                sb.Clear();
            }

            return true;
        }
    }
}