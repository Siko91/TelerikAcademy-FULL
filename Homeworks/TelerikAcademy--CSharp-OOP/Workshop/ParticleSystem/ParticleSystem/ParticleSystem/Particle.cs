using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class Particle : IRenderable, IAcceleratable
    {
        public MatrixCoords Position { get; protected set; }
        public MatrixCoords Speed { get; protected set; }
        
        
        public Particle(MatrixCoords position, MatrixCoords speed)
        {
            this.Position = position;
            this.Speed = speed;
        }


        public virtual IEnumerable<Particle> Update()
        {
            this.Move();
            return (new List<Particle>());
        }
        protected virtual void Move()
        {
            this.Position += this.Speed;
        }

        public virtual MatrixCoords GetTopLeft()
        {
            return this.Position;
        }

        public virtual char[,] GetImage()
        {
            return new char[,] { { '#' } };
        }


        public virtual  bool Exists
        {
            get { return true; }
        }

        public virtual void Accelerate(MatrixCoords acceleration)
        {
            this.Speed += acceleration;
        }
    }
}
