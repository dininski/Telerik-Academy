using System;
using System.IO;

class CompareTwoTextFiles
{
    static void Main(string[] args)
    {
        int sameLines = 0;
        int differentLines = 0;
        string firstFilePath = "../../file1.txt";
        string secondFilePath = "../../file2.txt";
        StreamReader firstFile = new StreamReader(firstFilePath);
        StreamReader secondFile = new StreamReader(secondFilePath);

        using (firstFile)
        {
            using (secondFile)
            {
                while (!firstFile.EndOfStream)
                {
                    if (firstFile.ReadLine() == secondFile.ReadLine())
                    {
                        sameLines++;
                    }
                    else
                    {
                        differentLines++;
                    }
                }
            }
        }
        Console.WriteLine("The two files have {0} lines that are the same and {1} lines that are different",
                            sameLines, differentLines);
    }
}