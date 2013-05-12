using System;
using System.Collections.Generic;
using Poker.Common;

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
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            Hand myHand = new Hand(cards);
            //Console.WriteLine(checker.IsStraight(myHand));

            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            myHand = new Hand(cards);
            Console.WriteLine(myHand);
            Console.WriteLine(checker.IsStraight(myHand));

            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            hand = new Hand(cards);
            Console.WriteLine(hand);
            Console.WriteLine(checker.IsStraight(hand));

            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            hand = new Hand(cards);
            Console.WriteLine(checker.IsStraight(hand));
        }
    }
}
