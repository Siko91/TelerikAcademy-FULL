using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count == 0)
            {
                return false;
            }
            if (hand.Cards.Count > 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count-1; i++)
            {
                for (int y = i+1; y < hand.Cards.Count; y++)
                {
                    if (hand.Cards[i].Face == hand.Cards[y].Face &&
                        hand.Cards[i].Suit == hand.Cards[y].Suit)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            return (this.IsFlush(hand) && this.IsStraight(hand));
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int appearenceCounter = 1;
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int y = i + 1; y < hand.Cards.Count; y++)
                {
                    if (hand.Cards[i].Face == hand.Cards[y].Face)
                    {
                        appearenceCounter++;
                    }
                }
                if (appearenceCounter >= 4)
                {
                    return true;
                }
                else
                {
                    appearenceCounter = 1;
                }
            }
            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            int indexOfFirstPairCard1 = -1;
            int indexOfFirstPairCard2 = -1;
            int indexOfFirstPairCard3 = -1;
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int y = i + 1; y < hand.Cards.Count; y++)
                {
                    if (hand.Cards[i].Face == hand.Cards[y].Face)
                    {
                        for (int z = y+1; z < hand.Cards.Count; z++)
                        {
                            if (hand.Cards[i].Face == hand.Cards[z].Face)
	                        {
                                indexOfFirstPairCard1 = i;
                                indexOfFirstPairCard2 = y;
                                indexOfFirstPairCard3 = z;
                                break;
	                        }
                        }
                        if (indexOfFirstPairCard1 != -1)
                        {
                            break;
                        }
                    }
                }
                if (indexOfFirstPairCard1 != -1)
                {
                    break;
                }
            }
            if (indexOfFirstPairCard1 == -1)
            {
                return false;
            }
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (i == indexOfFirstPairCard1 || 
                    i == indexOfFirstPairCard2 || 
                    i == indexOfFirstPairCard3)
                {
                    continue;
                }
                for (int y = i + 1; y < hand.Cards.Count; y++)
                {
                    if (y == indexOfFirstPairCard1 || 
                        y == indexOfFirstPairCard2 || 
                        y == indexOfFirstPairCard3)
                    {
                        continue;
                    }
                    if (hand.Cards[i].Face == hand.Cards[y].Face)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsFlush(IHand hand)
        {
            int suitAppearenceCounter = 0;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int y = i + 1; y < hand.Cards.Count; y++)
                {
                    if (hand.Cards[i].Suit == hand.Cards[y].Suit)
                    {
                        suitAppearenceCounter++;
                    }
                }
                if (suitAppearenceCounter >= 3)
                {
                    return true;
                }
                else
                {
                    suitAppearenceCounter = 0;
                }
            }
            return false;
        }

        public bool IsStraight(IHand hand)
        {
            List<int> facesSorted = new List<int>();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                facesSorted.Add((int)hand.Cards[i].Face);
            }
            facesSorted.Sort();

            for (int i = 1; i < facesSorted.Count; i++)
            {
                if (facesSorted[0] + i != facesSorted[0+i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            int appearenceCounter = 1;
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int y = i + 1; y < hand.Cards.Count; y++)
                {
                    if (hand.Cards[i].Face == hand.Cards[y].Face)
                    {
                        appearenceCounter++;
                    }
                }
                if (appearenceCounter >= 3)
                {
                    return true;
                }
                else
                {
                    appearenceCounter = 1;
                }
            }
            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            int indexOfFirstPairCard1 = -1;
            int indexOfFirstPairCard2 = -1;
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int y = i + 1; y < hand.Cards.Count; y++)
                {
                    if (hand.Cards[i].Face == hand.Cards[y].Face)
                    {
                        indexOfFirstPairCard1 = i;
                        indexOfFirstPairCard2 = y;
                        break;
                    }
                }
                if (indexOfFirstPairCard1 != -1)
                {
                    break;
                }
            }
            if (indexOfFirstPairCard1 == -1)
            {
                return false;
            }
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                if (i == indexOfFirstPairCard1 || i == indexOfFirstPairCard2)
                {
                    continue;
                }
                for (int y = i + 1; y < hand.Cards.Count; y++)
                {
                    if (y == indexOfFirstPairCard1 || y == indexOfFirstPairCard2)
                    {
                        continue;
                    }
                    if (hand.Cards[i].Face == hand.Cards[y].Face)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int y = i + 1; y < hand.Cards.Count; y++)
                {
                    if (hand.Cards[i].Face == hand.Cards[y].Face)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if ((int)hand.Cards[i].Face > 10)
                {
                    return true;
                }
            }
            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            IHand[] hands = { firstHand, secondHand };
            int[] powerOfHands = { 0, 0 };

            for (int i = 0; i < hands.Length; i++)
            {
                if (this.IsStraightFlush(hands[i]))
                {
                    powerOfHands[i] = 9;
                }
                else if (this.IsFourOfAKind(hands[i]))
                {
                    powerOfHands[i] = 8;
                }
                else if (this.IsFullHouse(hands[i]))
                {
                    powerOfHands[i] = 7;
                }
                else if (this.IsFlush(hands[i]))
                {
                    powerOfHands[i] = 6;
                }
                else if (this.IsStraight(hands[i]))
                {
                    powerOfHands[i] = 5;
                }
                else if (this.IsThreeOfAKind(hands[i]))
                {
                    powerOfHands[i] = 4;
                }
                else if (this.IsTwoPair(hands[i]))
                {
                    powerOfHands[i] = 3;
                }
                else if (this.IsOnePair(hands[i]))
                {
                    powerOfHands[i] = 2;
                }
                else if (this.IsHighCard(hands[i]))
                {
                    powerOfHands[i] = 1;
                }
            }

            if (powerOfHands[0] != powerOfHands[1])
            {
                return powerOfHands[0].CompareTo(powerOfHands[1]);
            }
            else // compare Faces
            {
                // This is going to be VERY wrong
                // TODO - Refactor the whole solution, so that it could actually measure the combinations that the players have, and not just the sums of their hands.
                // It's not enough to look if there are combinations. The combinations need to be marked as such.
                // Yeah right - Like I'd do that.
                powerOfHands[0] = 0;
                powerOfHands[1] = 0;
                for (int i = 0; i < hands.Length; i++)
                {
                    for (int y = 0; y < hands[i].Cards.Count; y++)
                    {
                        powerOfHands[i] += (int)hands[i].Cards[y].Face;
                    }
                }
                if (powerOfHands[0] != powerOfHands[1])
                {
                    return powerOfHands[0].CompareTo(powerOfHands[1]);
                }
                else // compare Suits
                {
                    // This is wrong for the very same reasons.

                    powerOfHands[0] = 0;
                    powerOfHands[1] = 0;
                    for (int i = 0; i < hands.Length; i++)
                    {
                        for (int y = 0; y < hands[i].Cards.Count; y++)
                        {
                            powerOfHands[i] += (int)hands[i].Cards[y].Suit;
                        }
                    }
                    return powerOfHands[0].CompareTo(powerOfHands[1]);
                }
            }
        }
    }
}
