using System;
using System.Linq;

namespace BunnyEscape.Core
{
    public class UIText : GameObject
    {
        public UIText(string text, Point2D position, Point2D size) : base(position, size)
        {
            this.Text = text;
        }

        public string Text { get; set; }

        public bool IsVisible()
        {
            return true;
        }
    }
}