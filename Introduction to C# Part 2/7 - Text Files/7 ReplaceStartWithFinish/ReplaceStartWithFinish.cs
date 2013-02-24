using System;
using System.IO;

class ReplaceStartWithFinish
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
                    sw.WriteLine(reader.ReadLine().Replace("start", "finish"));
                }
            }
        }
    }
}