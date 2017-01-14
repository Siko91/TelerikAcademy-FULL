using System;
using System.Linq;
using BunnyEscape.Core.Interfaces;

namespace BunnyEscape.Core
{
    public class GameCharacter : PhysicalObject, IGameCharacter
    {
        public EventHandler ImageChangedEvent;

        public GameCharacter(
            Point2D position, Point2D size, double weight) : base(position, size, weight)
        {
        }

        public override string ImagePath
        {
            get
            {
                return base.ImagePath;
            }
            set
            {
                if (this.ImagePath != value)
                {
                    base.ImagePath = value;
                    if (this.ImageChangedEvent != null)
                    {
                        this.ImageChangedEvent(this, null);
                    }
                }
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            this.UpdateImagePath();
        }

        public virtual void UpdateImagePath()
        {
        }
    }
}