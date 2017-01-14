using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardToStringShouldFollowTheGivenFormat()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);

            Assert.AreEqual("Ace of Clubs", card.ToString());
        }

        [TestMethod]
        public void CardToStringShouldFollowTheGivenFormatWhenEnumIsAritmeticallyChanged()
        {
            ICard card = new Card(CardFace.Ace-1, CardSuit.Clubs+1);

            Assert.AreEqual("King of Diamonds", card.ToString());
        }
    }
}
