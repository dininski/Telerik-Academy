using System;
using System.IO;

class ConcatenateTwoTextFiles
{
    public static void AddFileContentsToNewFile(string filePath, StreamReader reader, StreamWriter sw)
    {
        reader = new StreamReader(filePath);
        using (reader)
        {
            while (!reader.EndOfStream)
            {
                sw.WriteLine(reader.ReadLine());
            }
        }
    }

    static void Main(string[] args)
    {
        string file1Path = "../../file1.txt";
        StreamReader reader = new StreamReader(file1Path);
        string file2Path = "../../file2.txt";
        string outputFile = "../../bothFiles.txt";

        StreamWriter sw = new StreamWriter(outputFile);
        using (sw)
        {
            AddFileContentsToNewFile(file1Path, reader, sw);
            AddFileContentsToNewFile(file2Path, reader, sw);
        }
    }
}