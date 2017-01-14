using System;
using System.Linq;

namespace BunnyEscape.Core.GamePresets
{
    internal class CarriedPassableCollider : CollidingObject
    {
        private readonly GameObject Parent;
        private Point2D Offset;

        public CarriedPassableCollider(Point2D offset, Point2D size, GameObject parent) : base(null, size)
        {
            this.Parent = parent;
            this.Offset = offset;
        }

        public override Point2D Position
        {
            get
            {
                return new Point2D(
                    this.Parent.Position.X + this.Offset.X,
                    this.Parent.Position.Y + this.Offset.Y);
            }
            set
            {
                this.Offset = value;
            }
        }

        public override void OnCollisionWith(CollidingObject obj)
        {
            // this is a trigger colider. It Doesn't do anything on collision.
        }
    }
}