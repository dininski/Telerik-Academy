namespace PokerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class HandToStringTests
    {
        [TestMethod]
        public void NoCardsInHandToStringTest()
        {
            IList<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);
            var result = hand.ToString();
            Assert.AreEqual(string.Empty, result, "The hand's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void OneCardInHandToStringTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            var result = hand.ToString();
            Assert.AreEqual("10♦", result, "The hand's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void FiveCardsInHandToStringTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            var result = hand.ToString();
            Assert.AreEqual("A♣ 2♦ 9♥", result, "The hand's ToString() method does not operate correctly");
        }
    }
}
