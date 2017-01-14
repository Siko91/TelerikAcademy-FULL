using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SazaracsMagicSword.GameObjects;

namespace SazaracsMagicSword.Data
{
    public class Dangers
    {
        static Enemyes enms = new Enemyes();

        public List<DangerousTerritory> Level1Dangers = new List<DangerousTerritory>()
        {
            new DangerousTerritory(0.1, enms.Wolf),
            new DangerousTerritory(0.1, enms.Gnome),
            new DangerousTerritory(0.1, enms.Bandit),
            new DangerousTerritory(1, enms.TheLordOfFire) /// Boss
        };
        public List<DangerousTerritory> Level2Dangers = new List<DangerousTerritory>()
        {
            new DangerousTerritory(0.2, enms.StrongBandit),
            new DangerousTerritory(0.2, enms.Bear),
            new DangerousTerritory(0.2, enms.HugeSpider),
            new DangerousTerritory(1, enms.TheWareWolf) /// Boss
        };
        public List<DangerousTerritory> Level3Dangers = new List<DangerousTerritory>()
        {
            new DangerousTerritory(0.3, enms.Assassin),
            new DangerousTerritory(0.3, enms.Magician),
            new DangerousTerritory(0.3, enms.Demon),
            new DangerousTerritory(1, enms.Sazarac) /// Boss
        };
    }
}
