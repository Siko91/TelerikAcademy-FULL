using BunnyEscape.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.Models
{
    public abstract class Score : IScore
    {
        public Score(long points, string playerName)
        {
            this.Points = points;
            this.PlayerName = playerName;
            this.Country = new GeolocationHandler().GetCountryName().Result;
        }

        public Score()
        {
            this.Country = "";
            this.PlayerName = "";
        }

        private string playerName;
        private long points;
        private string country;

        public virtual long Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }
        public virtual string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }
        public virtual string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
    }
}
