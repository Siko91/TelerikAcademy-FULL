using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Mine : GatheringLocation
    {
        public Mine(string name) :
            base(name, LocationType.Mine, ItemType.Iron, ItemType.Armor)
        {
        }

        public override Item ProduceItem(string itemName)
        {
            return new Iron(itemName, null);
        }
    }
}
