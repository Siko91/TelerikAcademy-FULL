using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    class PartivleReppeler : Particle
    {
        public int RepelRadius { get; private set; }
        public int Power { get; private set; }
        public PartivleReppeler(MatrixCoords position, MatrixCoords speed, int repelRadius = 10, int Power = 10)
            : base(position,speed)
        {
            this.RepelRadius = repelRadius;
            this.Power = Power;
        }
        public override char[,] GetImage()
        {
            return new char[,] { { '&' } };
        }
    }
}
