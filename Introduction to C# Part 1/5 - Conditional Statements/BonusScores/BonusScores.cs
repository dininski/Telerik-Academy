using System;


class BonusScores
{
    static void Main()
    {
        int score;
        Console.WriteLine("Please enter a number in the range 1-9:");
        score = int.Parse(Console.ReadLine());
        switch (score)
        {
            case 1:
            case 2:
            case 3:
                score *= 10;
                break;
            case 4:
            case 5:
            case 6:
                score *= 100;
                break;
            case 7:
            case 8:
            case 9:
                score *= 1000;
                break;
            default:
                Console.WriteLine("You did not enter a number in the range 1-9");
                return;
        }
        Console.WriteLine("Score is {0}", score);
    }
}

