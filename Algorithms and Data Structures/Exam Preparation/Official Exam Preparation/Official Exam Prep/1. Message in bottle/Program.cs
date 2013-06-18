namespace _1.Message_in_bottle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static string code;
        static Dictionary<char, int> cipher;

        static void Main(string[] args)
        {
            cipher = new Dictionary<char, int>();
            code = Console.ReadLine();
            string cipherString = Console.ReadLine();
            FillCipher(cipherString);
            FindCombinations(0, code, 1);
        }

        private static void FindCombinations(int index, string code, int max)
        {
// to solve
        }

        static void FillCipher(string cipherString)
        {
            StringBuilder numberAsString = new StringBuilder();
            char currentChar;

            currentChar = cipherString[0];

            for (int i = 1; i < cipherString.Length; i++)
            {
                if (cipherString[i] >= 'A' && cipherString[i] <= 'Z')
                {
                    int numberCode = int.Parse(numberAsString.ToString());
                    cipher.Add(currentChar, numberCode);
                    currentChar = cipherString[i];
                    numberAsString = new StringBuilder();
                }
                else
                {
                    numberAsString.Append(cipherString[i]);
                }
            }

            cipher.Add(currentChar, int.Parse(numberAsString.ToString()));
        }
    }
}
