using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    class ChickenParticle : ChaoticParticle
    {
        private List<ChickenParticle> newChickens = new List<ChickenParticle>();
        private int maxDurationOfStop;
        private double chanceToStop;

        private int ticksLeftToStayStill;

        public ChickenParticle(MatrixCoords position, Random rndGen, double chanceToChangeDirection, double chanceToStop, int maxDurationOfStop)
            : base(position, rndGen, chanceToChangeDirection)
        {
            this.maxDurationOfStop = maxDurationOfStop;
            this.chanceToStop = chanceToStop;
        }

        public override IEnumerable<Particle> Update()
        {
            List<ChickenParticle> newChicks = new List<ChickenParticle>();

            if (this.ticksLeftToStayStill <= 0)
            {
                this.RandomiseDirection();

                if (rndGen.NextDouble() < chanceToStop)
                {
                    this.Speed = new MatrixCoords(0, 0);
                    this.ticksLeftToStayStill = rndGen.Next(0, maxDurationOfStop);
                }
            }
            else if (this.ticksLeftToStayStill > 0)
            {
                this.ticksLeftToStayStill--;

                if (this.ticksLeftToStayStill == 0)
                {
                    newChicks.Add(new ChickenParticle(
                        this.Position,
                        this.rndGen,
                        this.chanceToChangeDirection,
                        this.chanceToStop,
                        this.maxDurationOfStop));
                }
            }
            this.Move();
            return newChicks;
        }
        
        public override char[,] GetImage()
        {
            if (this.ticksLeftToStayStill > 0)
            {
                return new char[,] { { '0' } };
            }
            return new char[,] { { (char)8225 } };
        }
    }
}
