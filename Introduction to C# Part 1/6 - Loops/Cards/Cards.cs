using System;

class Cards
{
    static void Main()
    {
        //easiest way:
        String cardHolder = "";
        String[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        String[] cardNames = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        foreach (String suit in suits)
        {
            foreach (String card in cardNames)
            {
                cardHolder = card + " of " + suit;
                Console.WriteLine(cardHolder);
            }
        }


        Console.WriteLine("\n\n");

        //for + switch/case way:
        String cardSuit = "";
        String cardValue = "";
        for (int i = 0; i < 13; i++)
        {
            cardHolder = "";
            switch (i)
            {
                case 0:
                    cardValue = "Ace";
                    break;
                case 1:
                    cardValue = "Deuce";
                    break;
                case 2:
                    cardValue = "Three";
                    break;
                case 3:
                    cardValue = "Four";
                    break;
                case 4:
                    cardValue = "Five";
                    break;
                case 5:
                    cardValue = "Six";
                    break;
                case 6:
                    cardValue = "Seven";
                    break;
                case 7:
                    cardValue = "Eight";
                    break;
                case 8:
                    cardValue = "Nine";
                    break;
                case 9:
                    cardValue = "Ten";
                    break;
                case 10:
                    cardValue = "Jack";
                    break;
                case 11:
                    cardValue = "Queen";
                    break;
                case 12:
                    cardValue = "King";
                    break;
            }
            cardHolder += " of ";
            for (int n = 0; n < 4; n++)
            {
                switch (n)
                {
                    case 0:
                        cardSuit = "Clubs";
                        break;
                    case 1:
                        cardSuit = "Diamonds";
                        break;
                    case 2:
                        cardSuit = "Hearts";
                        break;
                    case 3:
                        cardSuit = "Spades";
                        break;
                }
                Console.WriteLine("{0} of {1}", cardValue, cardSuit);
            }
        }
    }
}