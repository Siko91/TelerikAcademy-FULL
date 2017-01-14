using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SazaracsMagicSword.GameObjects
{
    public struct VisualBrick
    {
        public ConsoleColor color { get; set; }
        public char ch { get; set; }
        
        public VisualBrick (ConsoleColor color, char ch) : this()
        {
            this.color = color;
            this.ch = ch;
        }
    }
}
