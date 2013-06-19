using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword
{
    public class Program
    {
        static int crosswordSize;
        static string[] words;
        static string[] solution;
        static HashSet<string> allWords;

        public static void Main(string[] args)
        {
            crosswordSize = int.Parse(Console.ReadLine());
            words = new string[crosswordSize * 2];
            solution = new string[crosswordSize];
            allWords = new HashSet<string>();

            for (int i = 0; i < crosswordSize * 2; i++)
            {
                string word = Console.ReadLine();
                words[i] = word;
                allWords.Add(word);
            }

            Array.Sort(words);

            try
            {
                Solve(0, 0);
            }
            catch
            {
                PrintSolution();
                return;
            }

            Console.WriteLine("NO SOLUTION!");
        }

        static void Solve(int index, int currentWord)
        {
            if (index == crosswordSize)
            {
                if (IsValidSolution())
                {
                    throw new Exception();
                }
            }
            else
            {
                for (int i = 0; i < crosswordSize * 2; i++)
                {
                    solution[index] = words[i];
                    Solve(index + 1, i);
                }
            }
        }

        static void PrintSolution()
        {
            for (int i = 0; i < crosswordSize; i++)
            {
                Console.WriteLine(solution[i]);
            }
        }

        static bool IsValidSolution()
        {
            StringBuilder sb = new StringBuilder();
            for (int ch = 0; ch < solution.Length; ch++)
            {
                sb = new StringBuilder();
                for (int word = 0; word < solution.Length; word++)
                {
                    sb.Append(solution[word][ch]);
                }

                if (!allWords.Contains(sb.ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
