using System;
using System.Linq;
using BunnyEscape.Core.GamePresets.Events;

namespace BunnyEscape.Core.GamePresets
{
    public class KickableLightObject : PhysicalObject
    {
        public KickableLightObject(Point2D position, Point2D size, string imagePath, double weight = 5) : base(position, size, weight)
        {
            this.ImagePath = imagePath;
            this.ImageSize = size;
        }

        public Point2D ImageSize { get; set; }

        public bool IsVisible()
        {
            return true;
        }


        public EventHandler SoundEvents;

        public override void OnCollisionWith(CollidingObject obj)
        {
            if (obj is Player)
            {
                this.AddForce(new Force(new Point2D(0,-1).ToAngle(), Force.PowerOfJumping, 100));
                return;
            }
            else if (obj is PhysicalObject)
            {
                if (this.SoundEvents != null)
                {
                    this.SoundEvents(this, new SoundEventArgs(){SoundType = SoundType.KickableObjectCollision});
                }
            }
            base.OnCollisionWith(obj);
        }

        public override void AddForce(Force force)
        {
            if (this.Forces.Count < 3)
            {
                base.AddForce(force);
                return;
            }
            else
            {
                var index = 0;
                var minTime = this.Forces[0].TimeLeft;
                for (int i = 1; i < this.Forces.Count; i++)
                {
                    if (this.Forces[i].TimeLeft < minTime)
                    {
                        minTime = this.Forces[i].TimeLeft;
                        index = i;
                    }
                }

                Force f = this.Forces[index];
                var angle = force.Angle;
                var power = f.Power + force.Power;
                var ms = force.InitialMilliseconds;
                this.Forces[index] = new Force(angle, power, ms);
            }
        }

    }
}