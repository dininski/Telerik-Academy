using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            switch (this.Face)
            {
                case CardFace.Two:
                    sb.Append('2');
                    break;
                case CardFace.Three:
                    sb.Append('3');
                    break;
                case CardFace.Four:
                    sb.Append('4');
                    break;
                case CardFace.Five:
                    sb.Append('5');
                    break;
                case CardFace.Six:
                    sb.Append('6');
                    break;
                case CardFace.Seven:
                    sb.Append('7');
                    break;
                case CardFace.Eight:
                    sb.Append('8');
                    break;
                case CardFace.Nine:
                    sb.Append('9');
                    break;
                case CardFace.Ten:
                    sb.Append("10");
                    break;
                case CardFace.Jack:
                    sb.Append('J');
                    break;
                case CardFace.Queen:
                    sb.Append('Q');
                    break;
                case CardFace.King:
                    sb.Append('K');
                    break;
                case CardFace.Ace:
                    sb.Append('A');
                    break;
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    sb.Append('♣');
                    break;
                case CardSuit.Diamonds:
                    sb.Append('♦');
                    break;
                case CardSuit.Hearts:
                    sb.Append('♥');
                    break;
                case CardSuit.Spades:
                    sb.Append('♠');
                    break;
            }

            return sb.ToString();
        }
    }        
}            
