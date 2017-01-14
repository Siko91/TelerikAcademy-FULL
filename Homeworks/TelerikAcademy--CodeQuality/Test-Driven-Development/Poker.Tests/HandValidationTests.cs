using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandValidationTests
    {
        IHand hand;
        readonly PokerHandsChecker checker = new PokerHandsChecker();

        private void NullifyHand()
        {
            hand = null;
        }

        [TestMethod]
        public void HandWithZeroCardsShouldNotBeValid()
        {
            NullifyHand();

            hand = new Hand(new List<ICard>() {});

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void HandShouldNotHaveMoreThanFiveCards()
        {
            NullifyHand();

            hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds)
            });

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void HandWithRepeatingCardsShouldNotBeValid()
        {
            NullifyHand();

            hand = new Hand(new List<ICard>() {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            });

            Assert.IsFalse(checker.IsValidHand(hand));
        }
    }
}
