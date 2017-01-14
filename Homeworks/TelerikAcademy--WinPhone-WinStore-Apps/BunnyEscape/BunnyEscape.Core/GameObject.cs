using System;
using System.Collections.Generic;
using System.Linq;
using BunnyEscape.Core.Interfaces;

namespace BunnyEscape.Core
{
    public class GameObject : IGameObject
    {

        public GameObject(Point2D position, Point2D size)
        {
            this.Position = position;
            this.Size = size;
        }

        public virtual Point2D Position { get; set; }

        public virtual Point2D Size { get; set; }

        public IEnumerable<Point2D> GetEdges()
        {
            var objTL = GetTopLeftPoint();
            var objTR = GetTopRightPoint();
            var objBR = GetBottomRightPoint();
            var objBL = GetBottomLeftPoint();
            return new[]
            {
                objTL,
                objTR,
                objBR,
                objBL,
                this.GetCenter()
            };
        }

        public Point2D GetBottomLeftPoint()
        {
            var objBL = new Point2D(this.Position.X, this.Position.Y + this.Size.Y);
            return objBL;
        }

        public Point2D GetBottomRightPoint()
        {
            var objBR = new Point2D(this.Position.X + this.Size.X, this.Position.Y + this.Size.Y);
            return objBR;
        }

        public Point2D GetTopLeftPoint()
        {
            Point2D objTL = this.Position;
            return objTL;
        }

        public Point2D GetTopRightPoint()
        {
            var objTR = new Point2D(this.Position.X + this.Size.X, this.Position.Y);
            return objTR;
        }

        public Point2D GetCenter()
        {
            return new Point2D(this.Position.X + (this.Size.X / 2), this.Position.Y + (this.Size.Y / 2));
        }

        public double DistanceTo(GameObject other)
        {
            return this.GetCenter().DistanceTo(other.GetCenter());
        }
        
        public double AngleTo(GameObject other) 
        {
            double angle = this.GetCenter().DirectionTo(other.GetCenter());
            angle %= 360;
            if (angle < 0)
            {
                angle = 360 - (-angle);
            }
            return angle;
        }

        public virtual void OnUpdate()
        {
        }
    }
}