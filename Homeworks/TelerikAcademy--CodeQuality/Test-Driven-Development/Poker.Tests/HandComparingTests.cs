using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandComparingTests
    {
        IHand hand1;
        IHand hand2;
        readonly PokerHandsChecker checker = new PokerHandsChecker();

        private void NullifyHands()
        {
            hand1 = null;
            hand2 = null;
        }

        [TestMethod]
        public void MorePowerfulCombinationsShouldBeMorePowerful()
        {
            NullifyHands();

            hand1 = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds)
            });
            hand2 = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds)
            });

            Assert.IsTrue((checker.CompareHands(hand1,hand2) > 0));
        }

        [TestMethod]
        public void EqualyPowerfulCombinationsShouldBeComparedByFaces()
        {
            NullifyHands();

            hand1 = new Hand(new List<ICard>() {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            });
            hand2 = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds)
            });

            Assert.IsTrue((checker.CompareHands(hand1, hand2) > 0));
        }

        [TestMethod]
        public void EqualyPowerfulCombinationsEqualByFacesShouldBeComparedBySuits()
        {
            NullifyHands();

            hand1 = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades)
            });
            hand2 = new Hand(new List<ICard>() {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)
            });

            Assert.IsTrue((checker.CompareHands(hand1, hand2) > 0));
        }
    }
}
