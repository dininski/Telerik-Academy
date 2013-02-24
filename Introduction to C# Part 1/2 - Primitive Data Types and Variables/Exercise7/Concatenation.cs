using System;

namespace Exercise7
{
    class Concatenation
    {
        static void Main()
        {
            string firstString = "Hello";
            string secondString = "World";
            string concatenatedString;
            object concatenateThem = firstString + " " + secondString;
            concatenatedString = (string)concatenateThem;
            Console.WriteLine(concatenatedString);
        }
    }
}
