namespace BiDictionaryProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            BiDictionary<int, string, string> bidict = new BiDictionary<int, string, string>();

            // add an element to bidictionary
            bidict.AddElement(10, "first", "someVal");

            //try to find the element using the first key
            Console.WriteLine(bidict.GetElementByFirstKey(10));
            
            //try to find the element using the second key
            Console.WriteLine(bidict.GetElementBySecondKey("first"));

            //try to find the element using both the first key and the second key
            Console.WriteLine(bidict.GetElementByTwoKeys(10, "first"));
        }
    }
}
