using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.GameObjects
{  
    [Serializable]
    public struct Statistics
    {
        private int strength;
        private int dexterity;
        private int eillPower;
        private int hitPoints;

        #region Properties
        public int Strength 
        {
            get { return this.strength; }
            set { this.strength = value; }
        }

        public int Dexterity 
        {
            get { return this.dexterity; }
            set { this.dexterity = value; }
        }

        public int EillPower 
        {
            get { return this.eillPower; }
            set { this.eillPower = value; }
        }

        public int HitPoints 
        {
            get { return this.hitPoints; }
            set { this.hitPoints = value; }
        }
        #endregion

        public Statistics(int str, int dex, int will) : this()
        {
            this.Strength = str;
            this.Dexterity = dex;
            this.EillPower = will;
            this.HitPoints = this.Strength * 4 + this.Dexterity * 3 + this.EillPower * 2;
        }

        public int RefreshHP()
        {
            return this.Strength * 4 + this.Dexterity * 3 + this.EillPower * 2;
        }
    }
}
