using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SortArrayByNumOfCharacters
{
    static void Main(string[] args)
    {
        String[] stringArray = { "word", "another word", "a string", "more strings", "and even more", "test" };

        Array.Sort(stringArray, (x, y) => x.Length.CompareTo(y.Length));

        foreach (var item in stringArray)
        {
            Console.WriteLine(item);
        }
    }
}
