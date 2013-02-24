using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "../../addLinesToMe.txt";
        string outputFilePath = "../../withLineNumbers.txt";
        StreamReader file = new StreamReader(inputFilePath);
        StreamWriter sw = new StreamWriter(outputFilePath);
        int currentLine = 1;
        using (sw)
        {
            using (file)
            {
                while (!file.EndOfStream)
                {
                    sw.Write("{0} ", currentLine);
                    sw.WriteLine(file.ReadLine());
                    currentLine++;
                }
            }
        }
    }
}