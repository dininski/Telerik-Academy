using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

class ReadXML
{

    static void Main(string[] args)
    {
        string path = "../../sample.xml";
        StreamReader reader = new StreamReader(path);
        using (reader)
        {
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                string tag = @"<.*?>";
                Console.WriteLine(Regex.Replace(currentLine, tag, string.Empty));
            }
        }
    }
}
