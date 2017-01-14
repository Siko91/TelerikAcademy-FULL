using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyEscape.Core.GamePresets
{
    enum Direction
    {
        Left = 0,
        Down = 90,
        Right = 180,
        Up = 270
    }

    class DirectionalBarrier : Barrier
    {
        private Direction direction;
        public DirectionalBarrier(Point2D position, Point2D size, string imagePath, Direction direction)
            : base(position, size, imagePath)
        {
            this.direction = direction;
        }

        public override void OnCollisionWith(CollidingObject obj)
        {
            if (obj as PhysicalObject == null)
            {
                return;
            }

            switch (this.direction)
            {
                case Direction.Left:
                    obj.Position.X = this.Position.X + this.Size.X ;
                    break;
                case Direction.Down:
                    obj.Position.Y = this.Position.Y - obj.Size.Y;
                    break;
                case Direction.Right:
                    obj.Position.X = this.Position.X - obj.Size.X;
                    break;
                case Direction.Up:
                    obj.Position.Y = this.Position.Y + this.Size.Y;
                    break;
                default:
                    break;
            }

        }
    }
}
