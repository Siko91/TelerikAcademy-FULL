using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SazaracsMagicSword.GameObjects
{
    public class Enemy : Human
    {
        private double chanceToAppear;
        private Statistics statistics;
        private double chanceToEscape;
        private Weapon weapon;

        #region Properties
        public double ChanceToAppear 
        {
            get { return this.chanceToAppear; }
            set { this.chanceToAppear = value; }
        }
        public Statistics Statistics
        { 
            get { return this.statistics; }
            set { this.statistics = value; } 
        }

        public double ChanceToEscape
        {
            get { return this.chanceToEscape; }
            set { this.chanceToEscape = value; }
        }

        public Weapon Weapon
        {
            get { return this.weapon; }
            set { this.weapon = value; }
        }
        #endregion


        public Enemy(string name, double chanceToAppear, Statistics statistics, double chanceToEscape, Weapon weapon, string[] image)
            : base(name, image)
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Name is empty.");
            }
            if (chanceToAppear <= 0 || chanceToAppear > 1)
            {
                throw new ArgumentException("chanceToAppear must be in the diapason of (0, 1].");
            }
            if (chanceToEscape < 0 || chanceToEscape > 1)
            {
                throw new ArgumentException("chanceToEscape must be in the diapason of [0, 1].");
            }

            this.chanceToAppear = chanceToAppear;
            this.statistics = statistics;
            this.chanceToEscape = chanceToEscape;
            this.weapon = weapon;
        }
    }
}
