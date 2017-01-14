using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public abstract class GatheringLocation : Location, IGatheringLocation
    {
        public GatheringLocation(string name, LocationType locType, 
            ItemType gatheredItemType, ItemType requiredItemType) :
            base(name, locType)
        {
            this.GatheredType = gatheredItemType;
            this.RequiredItem = requiredItemType;
        }

        public ItemType GatheredType
        {
            get;
            protected set;
        }

        public ItemType RequiredItem
        {
            get;
            protected set;
        }

        public abstract Item ProduceItem(string itemName);
    }
}
