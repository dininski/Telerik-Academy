using System;

class CharacterPositionsInAWord
{
    static void Main()
    {
        char[] alphabetCharacter = new char[52];

        //fill the array with the characters (both upper and lower case)
        for (int i = 0; i < 26; i++)
        {
            alphabetCharacter[i] = (char)('A' + i);
        }


        Console.WriteLine("Please enter a word in capital letters:");
        String wordToSearch = Console.ReadLine();


        Console.WriteLine((int)alphabetCharacter[0]);

        for (int i = 0; i < wordToSearch.Length; i++)
        {
            Console.WriteLine("letter: {0}, index: {1}", wordToSearch[i], (int) wordToSearch[i]-65);
            
        }
    }
}