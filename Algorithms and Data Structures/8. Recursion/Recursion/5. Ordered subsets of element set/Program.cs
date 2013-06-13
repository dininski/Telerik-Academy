/* Write a recursive program for generating and printing all ordered k-element subsets
 * from n-element set (variations Vkn).
	Example: n=3, k=2, set = {hi, a, b} =>
	(hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
*/

namespace OrderedSubsets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] elements = new string[] { "hi", "a", "b" };
            SubsetsGenerator<string> generator = new SubsetsGenerator<string>(elements);
            generator.PrintSubsets(2);

            // Alternative input. Can use any type data in an IEnumerable collection due to generics
            // Uncomment to see it in action:
            // List<char> charElements = new List<char>();
            // charElements.Add('a');
            // charElements.Add('b');
            // charElements.Add('c');
            // charElements.Add('d');
            // SubsetsGenerator<char> altGen = new SubsetsGenerator<char>(charElements);
            // altGen.PrintSubsets(3);
        }
    }
}
