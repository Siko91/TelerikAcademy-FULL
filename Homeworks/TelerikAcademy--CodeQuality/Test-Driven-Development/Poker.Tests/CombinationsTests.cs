using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CombinationsTests
    {
        IHand hand;
        readonly PokerHandsChecker checker = new PokerHandsChecker();

        private void NullifyHand()
        {
            hand = null;
        }

        [TestMethod]
        public void CheckerShouldRecognizeHighCardCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds)
            });

            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void CheckerShouldRecognizeOnePairCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds)
            });

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void CheckerShouldRecognizeTwoPairCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void CheckerShouldRecognizeThreeOfAKindCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void CheckerShouldRecognizeStraightCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void CheckerShouldRecognizeFlushCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs)
            });

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void CheckerShouldRecognizeFullHouseCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades)
            });

            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void CheckerShouldRecognizeFourOfAKindCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            });

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void CheckerShouldRecognizeStraightFlushCombination()
        {
            NullifyHand();

            IHand hand = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsTrue(checker.IsStraightFlush(hand));
        }
    }
}
