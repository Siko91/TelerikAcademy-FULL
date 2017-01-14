using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParticleSystem
{
    class MyAdvancedEngine : Engine
    {
        public MyAdvancedEngine(IRenderer renderer, IParticleOperator particleOperator, List<Particle> particles = null, int waitMs = 1000)
            : base(renderer, particleOperator, particles, waitMs)
        {
        }

        public override void Run()
        {
            List<Particle> newParticles = new List<Particle>();
            while (true)
            {
                this.renderer.RenderAll();
                this.renderer.ClearQueue();
                foreach (var particle in particles)
                {
                    newParticles.AddRange(particleOperator.OperateOn(particle));
                }

                particles.AddRange(newParticles);
                foreach (var particle in this.particles)
                {
                    renderer.EnqueueForRendering(particle);
                }
                this.particleOperator.TickEnded();
                Thread.Sleep(this.waitMs);
            }
        }
    }
}
