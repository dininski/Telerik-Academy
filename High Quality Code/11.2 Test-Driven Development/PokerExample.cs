using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            //Console.WriteLine(checker.IsValidHand(hand));
            //Console.WriteLine(checker.IsOnePair(hand));
            //Console.WriteLine(checker.IsTwoPair(hand));

            // vasil test
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            Hand myHand = new Hand(cards);
            Console.WriteLine(checker.IsOnePair(myHand));            
        }
    }
}
