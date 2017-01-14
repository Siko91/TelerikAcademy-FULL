using System;
using System.Collections.Generic;
using SazaracsMagicSword.GameObjects;

namespace SazaracsMagicSword.Data
{
    public class Enemyes
    {
        #region Fields
        static Images img = new Images();
        static Weapons wpns = new Weapons();

        private List<Enemy> weakEnemyes = new List<Enemy>()
        {
            new Enemy("Wolf", 0.1, new Statistics(15, 15, 0), 0.9, wpns.WeakClaws, img.Dog),
            new Enemy("Gnome", 0.1, new Statistics(15, 15, 0),0.9,wpns.GnomeSword,img.Gnome),
            new Enemy("Bandit",0.1,new Statistics(10, 10, 10),0.9,wpns.ShortSword,img.HumanWithSword)
        };

        private List<Enemy> averageEnemyes = new List<Enemy>()
        {
            new Enemy("Strong Bandit",0.1,new Statistics(15, 15, 10),0.7,wpns.Sword,img.HumanWithTwoSabers),
            new Enemy("Bear",0.1,new Statistics(20, 20, 0),0.7,wpns.AverageClaw,img.Bear),
            new Enemy("Huge Spider",0.1,new Statistics(15, 25, 0),0.7,wpns.Venom,img.Spider)
        };

        private List<Enemy> strongEnemyes = new List<Enemy>()
        {
            new Enemy("Assassin",0.1,new Statistics(20, 20, 20),0.5,wpns.HiddenDagers,img.HumanWithTwoSabers),
            new Enemy("Magician",0.1,new Statistics(10, 10, 40),0.5,wpns.ChaoticMagic,img.HumanWithStaff),
            new Enemy("Demon",0.1,new Statistics(25, 10, 25),0.5,wpns.DemonicMagic,img.Demon)
        };

        private List<Enemy> bosses = new List<Enemy>()
        {
            new Enemy("The Lord Of Fire",0.1,new Statistics(10, 15, 20),0.5,wpns.FireMagic,img.HumanInFlame),
            new Enemy("The WareWolf",0.1,new Statistics(40, 15, 10),0.5,wpns.StrongClaws,img.WareWolf),
            new Enemy("Sazarac",0.1,new Statistics(30, 30, 30),0.5,wpns.SazaracMagicSword,img.HumanWithShieldAndBigSword)
        };
        #endregion

        #region Properties
        public List<Enemy> WeakEnemyes { get { return this.weakEnemyes; } }
        public List<Enemy> AverageEnemyes { get { return this.averageEnemyes; } }
        public List<Enemy> StrongEnemyes { get { return this.strongEnemyes; } }
        public List<Enemy> Bosses { get { return this.bosses; } }

        public Enemy Wolf { get { return this.weakEnemyes[0]; } }
        public Enemy Gnome { get { return this.weakEnemyes[1]; } }
        public Enemy Bandit { get { return this.weakEnemyes[2]; } }
        public Enemy StrongBandit { get { return this.averageEnemyes[0]; } }
        public Enemy Bear { get { return this.averageEnemyes[1]; } }
        public Enemy HugeSpider { get { return this.averageEnemyes[2]; } }
        public Enemy Assassin { get { return this.strongEnemyes[0]; } }
        public Enemy Magician { get { return this.strongEnemyes[1]; } }
        public Enemy Demon { get { return this.strongEnemyes[2]; } }
        public Enemy TheLordOfFire { get { return this.bosses[0]; } }
        public Enemy TheWareWolf { get { return this.bosses[1]; } }
        public Enemy Sazarac { get { return this.bosses[2]; } }
        #endregion
    }
}