using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.RunTime
{
    class DiceRoller
    {
        static Random rnd = new Random();

        public bool NewDice()
        {
            if (rnd.Next(0, 1).Equals(1))
            {
                return true;
            }
            return false;
        }
        public bool NewDice(double chanceToHappen)
        {
            if (rnd.NextDouble().CompareTo(chanceToHappen) <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
