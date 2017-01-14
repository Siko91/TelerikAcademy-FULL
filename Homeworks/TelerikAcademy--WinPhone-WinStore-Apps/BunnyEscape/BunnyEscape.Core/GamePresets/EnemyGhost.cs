using BunnyEscape.Core.GamePresets.Events;
using System;
using System.Collections.Generic;
namespace BunnyEscape.Core.GamePresets
{
    public class EnemyGhost : GameCharacter
    {
        private const double DefaultPower = 3;
        private const double DistanceToStartReaching = 5;
        private const string LeftImagePath = @"Resourses\Real\ghost-left.png";
        private const string RightImagePath = @"Resourses\Real\ghost-right.png";
        private const string ReachLeftImagePath = @"Resourses\Real\ghost-left-near.png";
        private const string ReachRightImagePath = @"Resourses\Real\ghost-right-near.png";

        public EnemyGhost(Point2D position, Point2D size, double weight, GameCharacter player)
            : base(position, size, weight)
        {
            this.Player = player;
            this.ImagePath = LeftImagePath;
            this.UsesPhisics = false;
        }

        public EventHandler SoundEvents;

        public bool IsReaching { get; set; }

        public EventHandler ScoreUpdatedEvent { get; set; }

        public GameCharacter Player { get; set; }

        public static EnemyGhost CreatePreset(Point2D position, Point2D size, GameCharacter player)
        {
            return new EnemyGhost(
                position,
                size,
                0.01,
                player);
        }
        public override IList<Force> Forces
        {
            get { return new List<Force>(); }
            set { }
        }
        public override void ApplyPhysicalEffects()
        {
            var hauntingForce = new Force(this.AngleTo(this.Player), Force.PowerOfGhosts, 0);
            hauntingForce.ApplySelfOn(this);
        }

        public override void OnUpdate()
        {
            if (!ColidesWith(Player))
            {
                base.OnUpdate();
                double direction = this.AngleTo(this.Player);
                this.AddForce(new Force(direction, DefaultPower, 100));
            }

            if (this.DistanceTo(this.Player) < DistanceToStartReaching)
            {
                this.IsReaching = true;
            }
            else
            {
                this.IsReaching = false;
            }
        }

        public override void UpdateImagePath()
        {
            double angle = this.AngleTo(this.Player);

            if (90 < angle && angle <= 270) // left
            {
                this.ImagePath = this.IsReaching ? ReachLeftImagePath : LeftImagePath;
            }
            else // right
            {
                this.ImagePath = this.IsReaching ? ReachRightImagePath : RightImagePath;
            }
        }

        public override void OnCollisionWith(CollidingObject obj)
        {
            if (this.ScoreUpdatedEvent != null)
            {
                bool GhostIsHitByFlyingObject = false;
                var kickable = obj as KickableLightObject;
                if (kickable != null && kickable.Forces.Count > 0)
                {
                    int points = 100;
                    if (kickable is Football)
                    {
                        points = 150;
                    }
                    GhostIsHitByFlyingObject = true;
                    this.ScoreUpdatedEvent(this, new ScoreEventArgs(points));
                }

                var pushable = obj as HeavyMovableObject;
                if (pushable != null && pushable.Forces.Count > 0)
                {
                    GhostIsHitByFlyingObject = true;
                    this.ScoreUpdatedEvent(this, new ScoreEventArgs(500));
                }

                this.ScoreUpdatedEvent(this, new ScoreEventArgs(1));

                if (GhostIsHitByFlyingObject)
                {
                    if (this.SoundEvents != null)
                    {
                        this.SoundEvents(this, new SoundEventArgs() { SoundType = SoundType.GhostBeingHit });
                    }
                }
                else
                {
                    if (this.SoundEvents != null)
                    {
                        this.SoundEvents(this, new SoundEventArgs() { SoundType = SoundType.GhostPassing });
                    }
                }
            }
        }
    }
}