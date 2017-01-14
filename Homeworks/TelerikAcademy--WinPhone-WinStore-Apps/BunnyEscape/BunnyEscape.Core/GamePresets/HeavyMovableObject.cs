using System;
using System.Linq;

namespace BunnyEscape.Core.GamePresets
{
    public class HeavyMovableObject : PhysicalObject
    {
        private readonly double luft = 0.1;

        public HeavyMovableObject(Point2D position, Point2D size, string imagePath) : base(position, size, 35)
        {
            this.ImagePath = imagePath;
            this.ImageSize = size;
        }

        public Point2D ImageSize { get; set; }

        public bool IsVisible()
        {
            return true;
        }

        public override void OnCollisionWith(CollidingObject obj)
        {
            base.OnCollisionWith(obj);

            if (obj as PhysicalObject == null)
            {
                return;
            }

            var middleBottomPoint = new Point2D(
                obj.Position.X + obj.Size.X / 2,
                obj.Position.Y + obj.Size.Y);
            var distanceY = this.Position.Y - obj.GetCenter().Y;

            if (PointIsInside(middleBottomPoint) &&
                distanceY > obj.Size.Y / 3)
            {
                obj.Position.Y += (0.16 * obj.Size.Y);
            }
        }
    }
}