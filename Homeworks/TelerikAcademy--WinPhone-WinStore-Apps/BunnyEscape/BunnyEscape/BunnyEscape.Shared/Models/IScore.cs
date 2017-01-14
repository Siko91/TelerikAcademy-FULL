using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.Models
{
    public interface IScore
    {
        long Points { get; set; }

        string PlayerName { get; set; }

        string Country { get; set; }
    }
}
