namespace Methods.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TextOperations
    {
        /// <summary>
        /// Converts <paramref name="number"/> to word.
        /// </summary>
        /// <param name="number">A single digit number</param>
        /// <returns>Returns the word of the number in English</returns>
        public static string GetNumberAsWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentOutOfRangeException("Invalid number - number must a single digit integer!");
        }
    }
}
