using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.GameObjects
{
    public class DangerousTerritory
    {
        public double Chance { get; set; }
        public Enemy enemyToAppear { get; set; }

        public DangerousTerritory(double Chance, Enemy enemyToAppear)
        {
            this.Chance = Chance;
            this.enemyToAppear = enemyToAppear;
        }
    }
}
