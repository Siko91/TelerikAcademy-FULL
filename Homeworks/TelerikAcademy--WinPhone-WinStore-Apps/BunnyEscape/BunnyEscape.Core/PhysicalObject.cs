using System;
using System.Collections.Generic;
using System.Linq;
using BunnyEscape.Core.Interfaces;

namespace BunnyEscape.Core
{
    public class PhysicalObject : CollidingObject, IPhysicalObject
    {
        public const double gravityPower = Force.PowerOfGravity;
        public const double gravityWeightFactor = 0.01;

        protected IList<Force> forces;
        protected Force gravity;
        protected double weight;

        public PhysicalObject(Point2D position, Point2D size, double weight) : base(position, size)
        {
            this.Weight = weight;
            this.Forces = new List<Force>();
            this.gravity = new Force(
                new Point2D(0,1).ToAngle(),
                gravityPower + this.Weight * gravityWeightFactor,
                0);
            this.UsesPhisics = true;
        }
        public bool UsesPhisics { get; set; }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        public virtual IList<Force> Forces
        {
            get
            {
                return this.forces;
            }
            set
            {
                this.forces = value;
            }
        }

        public virtual void ApplyPhysicalEffects()
        {
            var indexesOfForcesToRemove = new List<int>();
            for (int i = 0; i < this.Forces.Count; i++)
            {
                this.Forces[i].ApplySelfOn(this);

                if (this.Forces[i].Expiration.CompareTo(DateTime.Now) < 0) 
                {
                    indexesOfForcesToRemove.Add(i);
                }
            }

            this.gravity.ApplySelfOn(this);

            // removes from end to start
            indexesOfForcesToRemove.Sort();
            for (int i = indexesOfForcesToRemove.Count-1; i >= 0; i--)
            {
                this.Forces.RemoveAt(indexesOfForcesToRemove[i]);
            }
        }


        public virtual void AddForce(Force force)
        {
            this.Forces.Add(force);
        }

        public override void OnCollisionWith(CollidingObject obj)
        {
            var physic = obj as PhysicalObject;
            if (physic == null || !physic.UsesPhisics) 
            { 
                return; 
            }

            double angle = this.AngleTo(physic);

            double fromAngle = angle - 45;
            double toAngle = angle + 45;

            if (fromAngle < 0)
            {
                fromAngle = 360 - (-fromAngle);
            }
            if (toAngle > 360)
            {
                toAngle -= 360;
            }
            
            ICollection<Force> forcesToPass;
            forcesToPass = this.GetForcesToPass(fromAngle, toAngle);

            foreach (Force f in forcesToPass)
            {
                double weightFactor = this.GetWeightFactor(physic);
                double powerForNew = f.Power;
                var timeOFNew = (int)(f.InitialMilliseconds * weightFactor);
                physic.AddForce(new Force(f.Angle, powerForNew, timeOFNew));

                this.ChangeOwnForceOnCollision(f, physic);
            }
        }
 
        protected virtual double GetWeightFactor(PhysicalObject physic)
        {
            //double weightFactor = this.Weight / physic.Weight;
            ////weightFactor = Math.Min(1.5, weightFactor);
            ////weightFactor = Math.Max(0.5, weightFactor);

            //return weightFactor;
            return 1;
        }

        protected virtual void ChangeOwnForceOnCollision(Force force, PhysicalObject physic)
        {
            double weightFactor = this.Weight / physic.Weight;
            double newPower = force.Power - (force.Power / weightFactor);
            if (newPower < -force.Power / 2)
            {
                newPower = -force.Power / 2;
            }
            force.Power = newPower;
        }
 
        protected virtual ICollection<Force> GetForcesToPass(double fromAngle, double toAngle)
        {
            ICollection<Force> forcesToPass = new List<Force>();

            if (fromAngle > toAngle)
            {
                foreach (Force f in this.GetForcesWithAngleBetween(fromAngle, 360))
                {
                    forcesToPass.Add(f);
                }
                foreach (Force f in this.GetForcesWithAngleBetween(0, toAngle))
                {
                    forcesToPass.Add(f);
                }
            }
            else
            {
                foreach (Force f in this.GetForcesWithAngleBetween(fromAngle, toAngle))
                {
                    forcesToPass.Add(f);
                }
            }
            return forcesToPass;
        }

        protected ICollection<Force> GetForcesWithAngleBetween(double startAngle, double endAngle)
        {
            ICollection<Force> filteredForces = new List<Force>();
            foreach (Force f in this.Forces)
            {
                if (this.ForceIsBetweenAngle(f, startAngle, endAngle))
                {
                    filteredForces.Add(f);
                }
            }
            return filteredForces;
        }

        protected bool ForceIsBetweenAngle(Force f, double startAngle, double endAngle)
        {
            return startAngle <= f.Angle || f.Angle <= endAngle;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            var posX = this.Position.X;
            var posY = this.Position.Y;
        }
    }
}