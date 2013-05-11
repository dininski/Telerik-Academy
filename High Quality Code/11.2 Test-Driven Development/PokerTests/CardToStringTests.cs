namespace PokerTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class CardToStringTests
    {
        [TestMethod]
        public void QueenOfHeartsToStringTest()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Hearts);
            string result = card.ToString();
            Assert.AreEqual("Q♥", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void KingOfDiamondsToStringTest()
        {
            Card card = new Card(CardFace.King, CardSuit.Diamonds);
            string result = card.ToString();
            Assert.AreEqual("K♦", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void AceOfClubsToStringTest()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("A♣", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void TwoOfSpadesToStringTest()
        {
            Card card = new Card(CardFace.Two, CardSuit.Spades);
            string result = card.ToString();
            Assert.AreEqual("2♠", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void ThreeOfDiamondsToStringTest()
        {
            Card card = new Card(CardFace.Three, CardSuit.Diamonds);
            string result = card.ToString();
            Assert.AreEqual("3♦", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void FourOfClubsToStringTest()
        {
            Card card = new Card(CardFace.Four, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("4♣", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void FiveOfHeartsToStringTest()
        {
            Card card = new Card(CardFace.Five, CardSuit.Hearts);
            string result = card.ToString();
            Assert.AreEqual("5♥", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void SixOfDiamondsToStringTest()
        {
            Card card = new Card(CardFace.Six, CardSuit.Diamonds);
            string result = card.ToString();
            Assert.AreEqual("6♦", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void SeventOfClubsToStringTest()
        {
            Card card = new Card(CardFace.Seven, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("7♣", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void EightOfSpadesToStringTest()
        {
            Card card = new Card(CardFace.Eight, CardSuit.Spades);
            string result = card.ToString();
            Assert.AreEqual("8♠", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void NineOfHeartsToStringTest()
        {
            Card card = new Card(CardFace.Nine, CardSuit.Hearts);
            string result = card.ToString();
            Assert.AreEqual("9♥", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void TenOfClubsToStringTest()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("10♣", result, "The card's ToString() method does not operate correctly");
        }

        [TestMethod]
        public void JackOfDiamondsToStringTest()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Diamonds);
            string result = card.ToString();
            Assert.AreEqual("J♦", result, "The card's ToString() method does not operate correctly");
        }
    }
}
