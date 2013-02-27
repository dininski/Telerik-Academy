using System;
using System.Text;

public static class StringBuilderExtension
{
    public static string Substring(this StringBuilder str, int index, int length)
    {
        return str.ToString().Substring(index,length);
    }

    static void Main(string[] args)
    {
        StringBuilder someString = new StringBuilder();
        someString.Append("This is a test string");
        Console.WriteLine(someString.Substring(2, 4));
    }
}
