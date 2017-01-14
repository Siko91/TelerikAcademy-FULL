using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyEscape.Core.GamePresets.Events
{
    class ScoreEventArgs : EventArgs
    {
        public ScoreEventArgs(int score = 0)
        {
            this.Score = score;
        }

        public int Score { get; set; }
    }
}
