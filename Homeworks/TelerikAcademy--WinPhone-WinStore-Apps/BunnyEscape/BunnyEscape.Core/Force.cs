using System;
using System.Linq;

namespace BunnyEscape.Core
{
    public class Force
    {
        public const double PowerOfGravity = 1;
        public const double PowerOfWalking = 0.5;
        public const double PowerOfGhosts = 0.2;
        public const double PowerOfJumping = 1;

        public Force(double angle, double power, int milliseconds)
        {
            this.Angle = angle;
            this.Power = power;
            this.FadeOutFactor = power / milliseconds;
            this.Expiration = DateTime.Now.AddMilliseconds(milliseconds);

            this.InitialMilliseconds = milliseconds;
        }

        public double FadeOutFactor { get; set; }

        public double Angle { get; set; }

        public double Power { get; set; }

        public DateTime Expiration { get; set; }

        public double TimeLeft
        {
            get
            {
                return (this.Expiration - DateTime.Now).TotalMilliseconds;
            }
        }

        public int InitialMilliseconds { get; set; }

        public Point2D CalculateNextPosition(Point2D point)
        {
            double cos = Math.Cos(Math.PI * this.Angle / 180.0);
            double sin = Math.Sin(Math.PI * this.Angle / 180.0);

            double yChange = this.Power * sin;
            double xChange = this.Power * cos;

            double x = point.X + (float)xChange;
            double y = point.Y + (float)yChange;

            return new Point2D(x, y);
        }

        public void ApplySelfOn(PhysicalObject gameObject)
        {
            Point2D newPosition = this.CalculateNextPosition(gameObject.Position);
            gameObject.Position = newPosition;
        }
    }
}