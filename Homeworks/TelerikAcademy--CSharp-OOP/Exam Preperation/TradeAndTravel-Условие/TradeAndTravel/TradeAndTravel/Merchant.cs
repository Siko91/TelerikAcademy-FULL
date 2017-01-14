using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeAndTravel
{
    public class Merchant: Shopkeeper, ITraveller
    {
        public Merchant(string name, Location location)
            : base(name, location)
        {
        }

        public void TravelTo(Location location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("Location is Null");
            }
            this.Location = location;
        }
    }
}
