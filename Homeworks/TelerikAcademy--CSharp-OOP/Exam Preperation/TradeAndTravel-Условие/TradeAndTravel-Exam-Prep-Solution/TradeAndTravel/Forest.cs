using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Forest : GatheringLocation
    {
        public Forest(string name) :
            base(name, LocationType.Forest, ItemType.Wood, ItemType.Weapon)
        {
        }

        public override Item ProduceItem(string itemName)
        {
            return new Wood(itemName, null);
        }
    }
}
