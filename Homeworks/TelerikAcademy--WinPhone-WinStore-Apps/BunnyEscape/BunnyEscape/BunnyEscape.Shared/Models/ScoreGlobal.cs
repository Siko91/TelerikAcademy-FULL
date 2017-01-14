using System;
using System.Collections.Generic;
using System.Text;
using Parse;
using BunnyEscape.Handlers;

using Telerik.Everlive;
using Telerik.Everlive.Sdk.Core.Model.Base;

namespace BunnyEscape.Models
{
    public class ScoreGlobal : DataItem, IScore
    {
        private const string PointsPropName = "Points";
        private const string PlayerNamePropName = "PlayerName";
        private const string CountryPropName = "Country";
        private long points;
        private string playerName;
        private string country;

        private ScoreGlobal()
        {
            this.Country = "";
            this.PlayerName = "";
        }

        public ScoreGlobal(long points, string playerName)
        {
            this.Points = points;
            this.PlayerName = playerName;
            this.Country = new GeolocationHandler().GetCountryName().Result;
        }

        public long Points
        {
            get { return this.points; }
            set
            {
                this.points = value;
                this.OnPropertyChanged("Points");
            }
        }

        public string PlayerName
        {
            get { return this.playerName; }
            set
            {
                this.playerName = value;
                this.OnPropertyChanged("PlayerName");
            }
        }

        public string Country
        {
            get { return this.country; }
            set
            {
                this.country = value;
                this.OnPropertyChanged("Country");
            }
        }

       
    }
}
