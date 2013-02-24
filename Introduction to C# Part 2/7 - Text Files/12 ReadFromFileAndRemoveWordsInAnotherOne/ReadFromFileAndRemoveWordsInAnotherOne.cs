using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ReadFromFileAndRemoveWordsInAnotherOne
{
    static void Main(string[] args)
    {

        try
        {
            string pathToFileWithWords = "../../words.txt";
            string pattern = @"\b(" + String.Join("|", File.ReadAllLines(pathToFileWithWords)) + @")\b";
            string pathToFileWithText = "../../textFile.txt";
            StreamReader reader = new StreamReader(pathToFileWithText);
            string pathToNewFile = "../../fileWithRemovedWords.txt";
            StreamWriter sw = new StreamWriter(pathToNewFile);
            using (reader)
            {
                using (sw)
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Console.WriteLine(Regex.Replace(line, pattern, string.Empty));
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not Found exception caught");
        }

        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not Found exception caught");
        }

        catch (IOException)
        {
            Console.WriteLine("Input/Output exception caught");
        }

        catch (System.Security.SecurityException)
        {
            Console.WriteLine("Security Exception caught");
        }

        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Unauthorized Access Exception caught");
        }
    }
}
