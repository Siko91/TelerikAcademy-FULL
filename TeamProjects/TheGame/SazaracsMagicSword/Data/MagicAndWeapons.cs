using System;
using System.Collections.Generic;
using SazaracsMagicSword.GameObjects;

namespace SazaracsMagicSword.Data
{
    public class Spells
    {
        private List<Magic> basicSpells = new List<Magic>()
        {
            new Magic("Flash", 5, 0, 0.9),
            new Magic("FireBall", 15, 0,  0.1),
            new Magic("Freaze", 10, 0, 0.5)
        };

        private List<Magic> advancedSpells = new List<Magic>()
        {
            new Magic("Heal", 0, -30, 0),
            new Magic("Slow Time", 12, 0, 0.9),
            new Magic("Rock Slide", 25, 0, 0.4)
        };

        private List<Magic> masterSpells = new List<Magic>()
        {
            new Magic("Tornado", 40, 0, 0.2),
            new Magic("Bless", 0, -70, 0.5),
            new Magic("Curse", 100, 30, 0.2),
            new Magic("DOOM", 70, 20),
            new Magic("Steal Life", 30, -30, 0.3),
            new Magic("Tester's Magic", 50, 50, 0.6)

        };

        //Property is kept for legacy issues
        public List<Magic> BasicSpells { get { return this.basicSpells; } }

        //Property is kept for legacy issues
        public List<Magic> AdvancedSpells { get { return this.advancedSpells; } }

        //Property is kept for legacy issues
        public List<Magic> MasterSpells { get { return this.masterSpells; } }

        public Magic Flash { get { return this.basicSpells[0]; } }
        public Magic FireBall { get { return this.basicSpells[1]; } }
        public Magic Freeze { get { return this.basicSpells[2]; } }
        public Magic Heal { get { return this.advancedSpells[0]; } }
        public Magic SlowTime { get { return this.advancedSpells[1]; } }
        public Magic RockSlide { get { return this.advancedSpells[2]; } }
        public Magic Tornado { get { return this.masterSpells[0]; } }
        public Magic Bless { get { return this.masterSpells[1]; } }
        public Magic Curse { get { return this.masterSpells[2]; } }
        public Magic DOOM { get { return this.masterSpells[3]; } }
        public Magic StealLife { get { return this.masterSpells[4]; } }
        public Magic TestersMagic { get { return this.masterSpells[5]; } }
    }

    public class Weapons
    {
        private List<Weapon> weakWeapons = new List<Weapon>()
        {
            new Weapon("Knive", 5, null),
            new Weapon("Short Sword", 8, null),
            new Weapon("Hammer", 12, null),
            new Weapon("Weak Claws", 5, null),
            new Weapon("Gnome Sword", 7, null)
        };

        private List<Weapon> averageWeapons = new List<Weapon>()
        {
            new Weapon("Bow", 10, null),
            new Weapon("Sword", 13, null),
            new Weapon("Spear", 18, null),
            new Weapon("Claws", 15, null),
            new Weapon("Venom", 15, null)
        };

        private List<Weapon> goodWeapons = new List<Weapon>()
        {
            new Weapon("Revolver", 25, null),
            new Weapon("Holly Sword", 33, null),
            new Weapon("Heavy Hammer", 40, null),
            new Weapon("Hidden Dagers", 30, null),
            new Weapon("Chaotic Magic", 35, null),
            new Weapon("Demonic Magic", 40, null),


        };

        private List<Weapon> uniques = new List<Weapon>()
        {
            new Weapon("Fork of DOOM", 1, (new Spells()).DOOM),
            new Weapon("Sazarac's Magic Sword", 70, (new Spells()).StealLife), // the weapon of the final boss - Sazarac
            new Weapon("Fire Magic", 15, null),
            new Weapon("Claws", 30, null),
            new Weapon("Tester's Sword", 100, (new Spells()).TestersMagic)
        };

        //Property is kept for legacy issues
        public List<Weapon> WeakWeapons { get { return this.weakWeapons; } }

        //Property is kept for legacy issues
        public List<Weapon> AverageWeapons { get { return this.averageWeapons; } }

        //Property is kept for legacy issues
        public List<Weapon> GoodWeapons { get { return this.goodWeapons; } }

        //Property is kept for legacy issues
        private List<Weapon> Uniques { get { return this.uniques; } }

        public Weapon Knive { get { return this.weakWeapons[0]; } }
        public Weapon ShortSword { get { return this.weakWeapons[1]; } }
        public Weapon Hammer { get { return this.weakWeapons[2]; } }
        public Weapon WeakClaws { get { return this.weakWeapons[3]; } }
        public Weapon GnomeSword { get { return this.weakWeapons[4]; } }
        public Weapon Bow { get { return this.averageWeapons[0]; } }
        public Weapon Sword { get { return this.averageWeapons[1]; } }
        public Weapon Spear { get { return this.averageWeapons[2]; } }
        public Weapon AverageClaw { get { return this.averageWeapons[3]; } }
        public Weapon Venom { get { return this.averageWeapons[4]; } }
        public Weapon Revolver { get { return this.goodWeapons[0]; } }
        public Weapon HollySword { get { return this.goodWeapons[1]; } }
        public Weapon HeavyHammer { get { return this.goodWeapons[2]; } }
        public Weapon HiddenDagers { get { return this.goodWeapons[3]; } }
        public Weapon ChaoticMagic { get { return this.goodWeapons[4]; } }
        public Weapon DemonicMagic { get { return this.goodWeapons[5]; } }
        public Weapon ForkОfDOOM { get { return this.uniques[0]; } }
        public Weapon SazaracMagicSword { get { return this.uniques[1]; } }
        public Weapon FireMagic { get { return this.uniques[2]; } }
        public Weapon StrongClaws { get { return this.uniques[3]; } }
        public Weapon TestersSword { get { return this.uniques[4]; } }
    }
}
