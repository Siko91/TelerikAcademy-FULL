using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void HandToStringShouldFollowTheGivenFormat()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            });

            Assert.AreEqual("Ace of Clubs\nAce of Diamonds", hand.ToString());
        }

        [TestMethod]
        public void HandToStringShouldFollowTheGivenFormatWhenEnumIsAritmeticallyChanged()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace-1, CardSuit.Clubs+1),
                new Card(CardFace.Ace, CardSuit.Diamonds)
            });

            Assert.AreEqual("King of Diamonds\nAce of Diamonds", hand.ToString());
        }
    }
}
