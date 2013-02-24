using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class RemoveWordsStartingWithTest
{
    static void Main(string[] args)
    {
        //copy original file and rename it to testFile.txt
        string path = "../../testFile.txt";
        StreamReader reader = new StreamReader(path);
        StringBuilder result = new StringBuilder();

        using (reader)
        {
            while (!reader.EndOfStream)
            {
                var pattern = @"\btest\w*";
                string parsedString = Regex.Replace(reader.ReadLine(), pattern, string.Empty);
                result.AppendLine(parsedString);
                Console.WriteLine(parsedString);
            }
        }

        StreamWriter sw = new StreamWriter(path);

        using (sw)
        {
            for (int i = 0; i < result.Length; i++)
            {
                sw.Write(result[i]);
            }
        }

    }
}
