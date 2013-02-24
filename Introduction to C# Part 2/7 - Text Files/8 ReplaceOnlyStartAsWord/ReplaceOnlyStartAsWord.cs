using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceOnlyStartAsWord
{
    static void Main(string[] args)
    {
        string inputPath = "../../start.txt";
        StreamReader reader = new StreamReader(inputPath);
        string outputPath = "../../finish.txt";
        StreamWriter sw = new StreamWriter(outputPath);

        using (sw)
        {
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string currentLine = reader.ReadLine();
                    string pattern = @"\b(start)\b";
                    string replace = "finish";
                    sw.WriteLine(Regex.Replace(currentLine, pattern, replace));
                }
            }
        }
    }
}