using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    class ChaoticParticle : Particle
    {
        protected Random rndGen;
        protected double chanceToChangeDirection;

        public ChaoticParticle(MatrixCoords position, Random rndGen, double chanceToChangeDirection) : base(position, new MatrixCoords(0,0))
        {
            this.rndGen = rndGen;
            this.chanceToChangeDirection = chanceToChangeDirection;
        }

        public override IEnumerable<Particle> Update()
        {
            RandomiseDirection();
            return base.Update();
        }
        protected void RandomiseDirection()
        {
            if (rndGen.NextDouble() < chanceToChangeDirection)
            {
                base.Speed = new MatrixCoords(rndGen.Next(-2, 3), rndGen.Next(-2, 3));
            }
        }
        public override char[,] GetImage()
        {
            return new char[,] { { (char)2 } };
        }
    }
}
