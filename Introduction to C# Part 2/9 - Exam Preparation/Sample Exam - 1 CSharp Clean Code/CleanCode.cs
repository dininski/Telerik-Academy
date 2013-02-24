using System;


class CleanCode
{
    static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        bool isMultilineComment = false;
        bool openQuotes = false;
        bool addLine = false;
        bool whitespace = true;
        //bool oneLineComment = false;
        for (int i = 0; i < numberOfLines; i++)
        {
            string currentLine = Console.ReadLine();

            if (currentLine!="")
            {
                for (int character = 0; character < currentLine.Length; character++)
                {
                    if (currentLine[character] == '"' && currentLine[character-1] != '\\')
                    {
                        openQuotes = !openQuotes;
                    }
                    if (!openQuotes)
                    {
                        if ((character + 1 < currentLine.Length) && currentLine[character] == '/' && currentLine[character + 1] == '/' && !isMultilineComment)
                        {
                            addLine = true;
                            break;
                        }
                        else if ((character + 1 < currentLine.Length) && currentLine[character] == '/' && currentLine[character + 1] == '*')
                        {
                            isMultilineComment = true;
                        }
                        else if (currentLine[character] == '/' && currentLine[character - 1] == '*')
                        {
                            isMultilineComment = false;
                            addLine = true;
                            continue;
                        }
                    }

                    if (!isMultilineComment)
                    {
                        Console.Write(currentLine[character]);
                    }
                    
                }
                if (!isMultilineComment && !whitespace)
                {
                    whitespace = true;
                    Console.WriteLine();
                } 
            }

            //if (addLine)
            //{
            //    Console.WriteLine();
            //    addLine = false;
            //}

        }
    }
}
