using System;
using System.Collections.Generic;
using System.Linq;

namespace BunnyEscape.Core.GamePresets
{
    public class Football : KickableLightObject
    {
        public Football(Point2D position, Point2D size, string imagePath) : base(position, size, imagePath)
        {
        }

        protected override ICollection<Force> GetForcesToPass(double fromAngle, double toAngle)
        {
            ICollection<Force> forces = base.GetForcesToPass(fromAngle, toAngle);

            foreach (Force f in forces)
            {
                this.AddForce(new Force(this.OpositeAngle(f.Angle),f.Power / 2, f.InitialMilliseconds));
            }

            return forces;
        }
 
        private double OpositeAngle(double angle)
        {
            angle += 180;
            if (angle >= 360)
            {
                angle -= 360;
            }
            return angle;
        }
    }
}