using System;
using System.Text.RegularExpressions;

class ReverseWordOrder
{
    static void Main(string[] args)
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        char[] separators = new char[] { ',', ' ', '.', '!' };
        string[] result = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        for (int i = result.Length - 1; i >= 0; i--)
        {
            Console.Write("{0} ", result[i]);
        }
        Console.WriteLine();
    }
}
