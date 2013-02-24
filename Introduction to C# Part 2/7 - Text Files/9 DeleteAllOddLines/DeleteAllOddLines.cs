using System;
using System.IO;
using System.Collections.Generic;

class DeleteAllOddLines
{
    static void Main(string[] args)
    {
        //make a duplicate of original.txt and name it file.txt to see the example in action.
        string path = "../../file.txt";
        StreamReader reader = new StreamReader(path);
        List<string> onlyOddLines = new List<string>();
        using (reader)
        {
            int lineNumber = 1;
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                if (lineNumber % 2 == 1)
                {
                    onlyOddLines.Add(currentLine);
                }
                lineNumber++;
            }
        }

        StreamWriter sw = new StreamWriter(path);
        using (sw)
        {
            for (int i = 0; i < onlyOddLines.Count; i++)
            {
                sw.WriteLine(onlyOddLines[i]);
            }
        }
    }
}