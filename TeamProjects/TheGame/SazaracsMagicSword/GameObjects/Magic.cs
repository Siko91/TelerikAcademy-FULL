using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.GameObjects
{   [Serializable]
    public class Magic
    {
        public string Name;
        public int damage;
        public int damageOnSelf;
        public double chanceToStun;

        public Magic(string Name, int damage, int damageOnSelf)
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Magic must have a name");
            }
            this.Name = Name;
            this.damage = damage;
            this.damageOnSelf = damageOnSelf;
            this.chanceToStun = 0;
        }
        public Magic(string Name, int damage, int damageOnSelf, double chanceToCrippleFoe)
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Magic must have a name");
            }
            if (chanceToCrippleFoe < 0 || chanceToCrippleFoe > 1)
            {
                throw new ArgumentException("chanceToCrippleFoe must be between 0 and 1.");
            }
            this.Name = Name;
            this.damage = damage;
            this.damageOnSelf = damageOnSelf;
            this.chanceToStun = chanceToCrippleFoe;
        }
    }
}
