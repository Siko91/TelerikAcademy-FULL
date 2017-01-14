using BunnyEscape.Core.GamePresets;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.Core.GamePresets.Events
{
    public class SoundEventArgs : EventArgs
    {
        public SoundType SoundType {get;set;}
    }
}
