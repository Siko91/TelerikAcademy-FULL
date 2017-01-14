using System;
using System.Linq;
using BunnyEscape.Core.GamePresets.Events;

namespace BunnyEscape.Core.GamePresets
{
    public class Player : GameCharacter
    {
        protected string runLeftImagePath = @"Resourses\Lola bunny\left.png";
        protected string runRightImagePath = @"Resourses\Lola bunny\right.png";
        protected string standLeftImagePath = @"Resourses\Lola bunny\stop-left.png";
        protected string standRightImagePath = @"Resourses\Lola bunny\stop-right.png";
        protected string fallRightImagePath = @"Resourses\Lola bunny\falling-left.png";
        protected string fallLeftImagePath = @"Resourses\Lola bunny\falling-right.png";
        protected string jumpLeftImagePath = @"Resourses\Lola bunny\jump-left.png";
        protected string jumpRightImagePath = @"Resourses\Lola bunny\jump-right.png";
        protected string deathImagePath = @"Resourses\Lola bunny\dead.png";
        private readonly CollidingObject groundDetector;

        public Player(Point2D position, Point2D size, int weight)
            : base(position, size, weight)
        {
            this.IsAlive = true;
            this.IsGrounded = false;
            this.ImagePath = this.standRightImagePath;

            this.groundDetector = new CarriedPassableCollider(
                new Point2D(Size.X / 4, Size.Y),
                new Point2D(Size.X / 2, Size.Y / 3),
                this);
        }

        public EventHandler SoundEvents;

        public Force JumpForce { get; set; }

        public bool IsGrounded { get; private set; }

        public bool IsAlive { get; private set; }

        public bool DirectionIsRight { get; set; }

        public double TotalSpeed
        {
            get
            {
                double total = 0;
                foreach (Force f in this.Forces)
                {
                    total += f.Power;
                }
                return total;
            }
        }

        public static Player CreatePreset(Point2D position, Point2D size)
        {
            return new Player(position, size, 55);
        }

        public void GoToLeft(double power = Force.PowerOfWalking)
        {
            if (IsAlive)
            {
                this.AddForce(new Force(new Point2D(-5, -1).ToAngle(), power, 300));
                this.DirectionIsRight = false;

                if (this.SoundEvents != null)
                {
                    this.SoundEvents(this, new SoundEventArgs(){SoundType = SoundType.PlayerMove});
                }
            }
        }

        public void GoToRight(double power = Force.PowerOfWalking)
        {
            if (IsAlive)
            {
                this.AddForce(new Force(new Point2D(5, -1).ToAngle(), power, 300));
                this.DirectionIsRight = true;

                if (this.SoundEvents != null)
                {
                    this.SoundEvents(this, new SoundEventArgs() { SoundType = SoundType.PlayerMove });
                }
            }
        }

        public void Jump(double power = Force.PowerOfJumping)
        {
            if (IsGrounded && IsAlive)
            {
                var jumpForse = new Force(new Point2D(0, -1).ToAngle(), power, 500);
                this.AddForce(jumpForse);
                this.JumpForce = jumpForse;

                if (this.SoundEvents != null)
                {
                    this.SoundEvents(this, new SoundEventArgs() { SoundType = SoundType.PlayerJump });
                }
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            this.IsGrounded = false;
        }

        public override bool ColidesWith(CollidingObject obj)
        {
            if (obj is Barrier || obj is HeavyMovableObject)
            {
                if (this.groundDetector.ColidesWith(obj))
                {
                    this.IsGrounded = true;
                }
            }

            var collides = base.ColidesWith(obj);
            if (obj is EnemyGhost && collides)
            {
                this.IsAlive = false;
            }

            return collides;
        }

        public override void UpdateImagePath()
        {
            if (!this.IsAlive)
            {
                this.ImagePath = this.deathImagePath;
            }

            if (this.IsGrounded)
            {
                if (this.forces.Count > 0)
                {
                    this.ImagePath = this.DirectionIsRight ? this.runRightImagePath : this.runLeftImagePath;
                }
                else
                {
                    this.ImagePath = this.DirectionIsRight ? this.standRightImagePath : this.standLeftImagePath;
                }
            }
            else
            {
                if (this.JumpForce != null && this.JumpForce.Expiration.CompareTo(DateTime.Now) < 0)
                {
                    this.ImagePath = this.DirectionIsRight ? this.jumpRightImagePath : this.jumpLeftImagePath;
                }
                else
                {
                    this.JumpForce = null;
                    this.ImagePath = this.DirectionIsRight ? this.fallRightImagePath : this.fallLeftImagePath;
                }
            }
        }
    }
}