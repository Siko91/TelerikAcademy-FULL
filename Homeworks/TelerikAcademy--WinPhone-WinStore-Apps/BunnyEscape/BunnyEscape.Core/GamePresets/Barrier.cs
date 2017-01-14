using System;
using System.Linq;

namespace BunnyEscape.Core.GamePresets
{
    public class Barrier : CollidingObject
    {
        private const double Luft = 0.1;

        public Barrier(Point2D position, Point2D size, string imagePath) 
            : base(position, size)
        {
            this.ImagePath = imagePath;
            this.ImageSize = size;
        }

        public Point2D ImageSize { get; set; }

        public bool IsVisible()
        {
            return true;
        }

        public bool IsUnder(CollidingObject obj) 
        {
            var objTopRight = new Point2D(obj.Position.X + obj.Size.X, obj.Position.Y);
            return (
                (this.Position.X <= objTopRight.X ||
                 this.Position.X + this.Size.X <= obj.Position.X) &&
                this.Position.Y - obj.Position.Y < obj.Size.Y * 1.1 &&
                this.Position.Y - obj.Position.Y > obj.Size.Y * 0.9) ;
        }

        public override void OnCollisionWith(CollidingObject obj)
        {
            if (obj as PhysicalObject == null ||
                obj as EnemyGhost != null)
            {
                return;
            }

            //determine the direction and push the object outside
            double angle = this.AngleTo(obj);
            double sideAngle = (45 * (this.Size.Y / this.Size.X)) % 360;

            double topLeftAngle = 180 + sideAngle / 2;
            double bottomLeftAngle = 180 - sideAngle / 2;
            double topRightAngle = 360 - sideAngle / 2;
            double bottomRightAngle =  sideAngle / 2;

            if (topRightAngle < angle || angle <= bottomRightAngle) // other is right
            {
                obj.Position.X = this.Position.X + this.Size.X + Luft;
            }
            else if (bottomRightAngle < angle && angle <= bottomLeftAngle) // other is above
            {
                obj.Position.Y = this.Position.Y + this.Size.Y + Luft;
            }
            else if (bottomLeftAngle < angle && angle <= topLeftAngle) // other is left
            {
                obj.Position.X = this.Position.X - obj.Size.X - Luft;
            }
            else if (topLeftAngle < angle && angle <= topRightAngle) // other is bellow
            {
                obj.Position.Y = this.Position.Y - obj.Size.Y - Luft;
            }
        }
    }
}