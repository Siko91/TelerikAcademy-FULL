using System;
using System.Linq;
using BunnyEscape.Core.Interfaces;

namespace BunnyEscape.Core
{
    public class CollidingObject : GameObject, ICollidingObject
    {
        public CollidingObject(Point2D position, Point2D size)
            : base(position, size)
        {
        }

        public virtual string ImagePath { get; set; }

        public virtual bool ColidesWith(CollidingObject obj)
        {
            Point2D colisionDistance = new Point2D(
                (this.Size.X + obj.Size.X) / 2,
                (this.Size.Y + obj.Size.Y) / 2
                );
            
            Point2D actualDistance = new Point2D(
                Math.Abs(this.GetCenter().X - obj.GetCenter().X),
                Math.Abs(this.GetCenter().Y - obj.GetCenter().Y)
                );

            bool colisionX = colisionDistance.X > actualDistance.X;
            bool colisionY = colisionDistance.Y > actualDistance.Y;

            if (colisionX && colisionY)
            {
                return true;
            }
            return false;
        }

        public bool PointIsInside(Point2D p)
        {
            bool horizontalCollision = (this.Size.X / 2) < (Math.Abs(this.GetCenter().X - p.X));
            bool verticalCollision = (this.Size.Y / 2) < (Math.Abs(this.GetCenter().Y - p.Y));

            return horizontalCollision && verticalCollision;
        }

        public virtual void OnCollisionWith(CollidingObject obj)
        {
        }
    }
}