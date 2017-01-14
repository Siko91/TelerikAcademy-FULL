using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SazaracsMagicSword.GameObjects
{
    [Serializable]
    public class Hero : Human, IMove
    {
        public int level = 1;
        public Statistics statistics;
        public Statistics levelUpStats;
        public Weapon weapon;
        public Position position;

        #region Properties
        public Statistics Statistics
        { 
            get { return this.statistics; }
            set { this.statistics = value; }
        }

        public Statistics LevelUpStats 
        {
            get { return this.levelUpStats; }
            set { this.levelUpStats = value; }
        }

        public Weapon Weapon 
        {
            get { return this.weapon; }
            set { this.weapon = value; }
        }

        public Position Position 
        {
            get { return this.position; }
            set { this.position = value; }
        }

        #endregion

        #region Constructors
        public Hero(string name, Statistics statistics, Weapon weapon, string[] image, Statistics levelUpStats)
            : base(name, image)
        {
            
            this.Statistics = statistics;
            this.Weapon = weapon;
            this.LevelUpStats = levelUpStats;
        }
        #endregion

        #region Methods

        public void LevelUp()
        {
            this.level++;
            this.statistics.Strength += this.LevelUpStats.Strength;
            this.statistics.Dexterity += this.LevelUpStats.Dexterity;
            this.statistics.EillPower += this.LevelUpStats.EillPower;
            this.statistics.HitPoints = this.Statistics.RefreshHP();
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    this.position.row += -1;
                    break;
                case Direction.down:
                    this.position.row += 1;
                    break;
                case Direction.left:
                    this.position.col += -1;
                    break;
                case Direction.right:
                    this.position.col += 1;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
