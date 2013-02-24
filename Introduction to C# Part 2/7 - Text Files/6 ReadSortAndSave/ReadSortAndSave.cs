using System;
using System.IO;
using System.Collections.Generic;

class ReadSortAndSave
{
    static void Main(string[] args)
    {
        string inputFilePath = "../../namesUnsorted.txt";
        StreamReader reader = new StreamReader(inputFilePath);

        string outputFilePath = "../../namesSorted.txt";
        StreamWriter sw = new StreamWriter(outputFilePath);
        List<String> names = new List<string>();
        using (reader)
        {
            while (!reader.EndOfStream)
            {
                names.Add(reader.ReadLine());
            }
        }

        names.Sort();

        using (sw)
        {
            for (int i = 0; i < names.Count; i++)
            {
                sw.WriteLine(names[i]);
            }
        }
    }
}