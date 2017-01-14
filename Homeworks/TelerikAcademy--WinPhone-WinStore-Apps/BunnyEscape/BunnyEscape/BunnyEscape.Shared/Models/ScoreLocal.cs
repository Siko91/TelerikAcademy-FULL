using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.Models
{
    [Table("Scores")]
    public class ScoreLocal : Score
    {

        public ScoreLocal()
            : base()
        { 
        }

        public ScoreLocal(long points, string playerName) 
            : base(points, playerName) 
        {
        }

        [Indexed]
        [Column("Points")]
        public override long Points
        {
            get
            {
                return base.Points;
            }
            set
            {
                base.Points = value;
            }
        }

        [Column("PlayerName")]
        public override string PlayerName
        {
	          get 
	        { 
		         return base.PlayerName;
	        }
	          set 
	        { 
		        base.PlayerName = value;
	        }
        }

        [Column("Country")]
        public override string Country
        {
            get
            {
                return base.Country;
            }
            set
            {
                base.Country = value;
            }
        }
    }
}
