using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.Models
{
    public class Dialogue
    {
        public Dialogue(string background, string npcDialogue, IEnumerable<string> responses = null)
        {
            this.Background = background;
            this.NpcDialogue = npcDialogue;
            this.Responses = responses;
            if (this.Responses == null)
            {
                this.Responses = new List<string>();
            }
        }

        public string NpcDialogue { get; set; }
        public string Background { get; set; }
        public IEnumerable<string> Responses { get; set; }
    }
}
