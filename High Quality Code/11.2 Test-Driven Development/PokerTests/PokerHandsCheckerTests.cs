namespace PokerTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker.Common;

    [TestClass]
    public class PokerHandsCheckerTests
    {
        private static PokerHandsChecker handsChecker;

        [ClassInitialize]
        public static void InitHandsChecker(TestContext context)
        {
            handsChecker = new PokerHandsChecker();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestHandIsValidNullTest()
        {
            handsChecker.IsValidHand(null);
        }

        [TestMethod]
        public void TestHandIsValidWithLessThanFiveCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsValidHand(hand), "Not validating the hand correctly");
        }

        [TestMethod]
        public void TestHandIsValidWithDuplicateCard()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsValidHand(hand), "Not validating the hand correctly");
        }

        [TestMethod]
        public void TestHandWithFiveValidCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsValidHand(hand), "Not validating the hand correctly");
        }

        // Flush
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIsFlushNullValue()
        {
            handsChecker.IsFlush(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsFlushWithInvalidCards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            handsChecker.IsFlush(hand);
        }

        [TestMethod]
        public void TestIsFlushNotHasFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsFlush(hand), "Not checking for flush correctly");
        }

        [TestMethod]
        public void TestIsFlushHasFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsFlush(hand), "Not checking for flush correctly");
        }

        // Four Of a Kind
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIsFourOfAKindNullValue()
        {
            handsChecker.IsFourOfAKind(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsFourOfAKindInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            handsChecker.IsFourOfAKind(hand);
        }

        [TestMethod]
        public void TestFourOfAKindNoFourOfKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsFourOfAKind(hand), "Not validating for four of a kind correctly");
        }

        [TestMethod]
        public void TestFourOfAKindHasFourOfKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsFourOfAKind(hand), "Not validating for four of a kind correctly");
        }

        // High Card
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestHighCardNullValue()
        {
            handsChecker.IsHighCard(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHighCardInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            handsChecker.IsHighCard(hand);
        }

        [TestMethod]
        public void TestHighCardNoHighCard()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsHighCard(hand), "Not validating for high card correctly");
        }

        [TestMethod]
        public void TestHighCardHasHighCard()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsHighCard(hand), "Not validating for high card correctly");
        }

        // One pair
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestOnePairNullValue()
        {
            handsChecker.IsOnePair(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnePairInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            handsChecker.IsOnePair(hand);
        }

        [TestMethod]
        public void TestOnePairNoOnePair()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsOnePair(hand), "Not validating for high card correctly");
        }

        [TestMethod]
        public void TestOnePairHasOnePair()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsOnePair(hand), "Not validating for high card correctly");
        }

        // Two pair
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestTwoPairNullValue()
        {
            handsChecker.IsTwoPair(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTwoPairInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            handsChecker.IsTwoPair(hand);
        }

        [TestMethod]
        public void TestTwoPairNoTwoPair()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsTwoPair(hand), "Not validating for high card correctly");
        }

        [TestMethod]
        public void TestTwoPairHasTwoPair()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsTwoPair(hand), "Not validating for high card correctly");
        }

        // Three of a kind
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestThreeOfKindNullValue()
        {
            handsChecker.IsThreeOfAKind(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThreeOfKindInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            handsChecker.IsThreeOfAKind(hand);
        }

        [TestMethod]
        public void TestThreeOfKindNoThreeOfKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsThreeOfAKind(hand), "Not validating for high card correctly");
        }

        [TestMethod]
        public void TestThreeOfKindHasThreeOfKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsThreeOfAKind(hand), "Not validating for high card correctly");
        }

        [TestMethod]
        public void TestThreeOfKindHasFullHouse()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsThreeOfAKind(hand), "Not validating for high card correctly");
        }

        // Full house
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestFullHouseNullValue()
        {
            handsChecker.IsFullHouse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestFullHouseInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            handsChecker.IsFullHouse(hand);
        }

        [TestMethod]
        public void TestFullHouseNoFullHouse()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsFullHouse(hand), "Not validating for high card correctly");
        }

        [TestMethod]
        public void TestFullHouseHasFullHouse()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsFullHouse(hand), "Not validating for high card correctly");
        }

        // Straight
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestStraightNullValue()
        {
            handsChecker.IsStraight(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStraightInvalidHand()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            handsChecker.IsStraight(hand);
        }

        [TestMethod]
        public void TestStraightNoStraight()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsStraight(hand), "Not validating for straight correctly");
        }

        [TestMethod]
        public void TestStraightNoStraightHasFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            Assert.IsFalse(handsChecker.IsStraight(hand), "Not validating for straight correctly");
        }

        [TestMethod]
        public void TestStraightHasStraight2_6()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsStraight(hand), "Not validating for straight correctly");
        }

        [TestMethod]
        public void TestStraightHasStraightA_5()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsStraight(hand), "Not validating for straight correctly");
        }

        [TestMethod]
        public void TestStraightHasStraight10_A()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            Hand hand = new Hand(cards);
            Assert.IsTrue(handsChecker.IsStraight(hand), "Not validating for straight correctly");
        }
    }
}