using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.GameObjects;

namespace SazaracsMagicSword.Data
{
    public class HeroTypes
    {
        Weapons weaps = new Weapons();
        Spells spls = new Spells();
        Images imgs = new Images();

        public Hero Warrior()
        {
            Weapon weap = weaps.Hammer;
            weap.changeMagic(spls.Flash);

            return new Hero("hero",
                new Statistics(25, 10, 5),
                weap,
                imgs.HumanWithShieldAndBigSword,
                new Statistics(10, 5, 0)
                );
        }
        public Hero Rogue()
        {
            Weapon weap = weaps.ShortSword;
            weap.changeMagic(spls.Freeze);

            return new Hero("hero",
                new Statistics(10, 20, 10),
                weap,
                imgs.HumanWithTwoSabers,
                new Statistics(3, 9, 3)
                );
        }
        public Hero Mage()
        {
            Weapon weap = weaps.Knive;
            weap.changeMagic(spls.FireBall);

            return new Hero("hero",
                new Statistics(5, 10, 25),
                weap,
                imgs.HumanWithStaff,
                new Statistics(0, 5, 10)
                );
        }
        public Hero Cheater()
        {
            Weapon weap = weaps.TestersSword;
            return new Hero("Cheater",
                new Statistics(50, 50, 50),
                weap,
                imgs.HumanInFlame,
                new Statistics(20, 20, 20)
                );
        }
    }
}