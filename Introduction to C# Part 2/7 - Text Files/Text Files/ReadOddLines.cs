using System;
using System.IO;

class ReadOddLines
{
    public static void Main(string[] args)
    {
        string file = "../../sampleFile.txt";
        StreamReader reader = new StreamReader(file);

        using (reader)
        {
            int currentLineNumber = 1;
            
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                if (currentLineNumber % 2 == 1)
                {
                    Console.WriteLine(currentLine);
                }
                currentLineNumber++;
            }

        }
    }
}