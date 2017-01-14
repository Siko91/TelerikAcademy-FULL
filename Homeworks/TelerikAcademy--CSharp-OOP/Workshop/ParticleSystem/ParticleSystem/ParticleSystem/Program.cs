using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class Program
    {
        const int visibleConsoleCols = 60;
        const int visibleConsoleRows = 40;
        static void Main(string[] args)
        {
            #region FormatConsole
            ConsoleFormatter formatter = new ConsoleFormatter(
                visibleConsoleRows+3, 
                visibleConsoleCols+3, 
                ConsoleColor.Black, 
                ConsoleColor.White);
            formatter.Format();
            #endregion

            ConsoleRenderer renderer = new ConsoleRenderer(visibleConsoleRows, visibleConsoleCols);
            MyAdvancedParticleUpdater particleOperator = new MyAdvancedParticleUpdater();

            Random rnd = new Random();

            // warning - the reppeler doesn't work on ChaoticParticles and ChickenParticles.

            List<Particle> particles = new List<Particle>()
            {
                //new ParticleEmitter(new MatrixCoords(), new MatrixCoords(),rnd,5,1, GenRandomPart),
                //new Particle(new MatrixCoords(0,0),new MatrixCoords(2,2)),              // #
                //new Particle(new MatrixCoords(40,40),new MatrixCoords(-2,-2)),          // #
                //new PartivleReppeler(new MatrixCoords(30,35),new MatrixCoords(0,0), 20, 1), // &
                new ChaoticParticle(new MatrixCoords(20,20), rnd, 0.5),                 // Smile
                new ChickenParticle(new MatrixCoords(25,21), rnd, 0.99, 0.01, 4)        // doubleCross
            };

            MyAdvancedEngine engine = new MyAdvancedEngine(renderer, particleOperator, particles, 500);
            engine.Run();
        }
        static Particle GenRandomPart(ParticleEmitter emitterParameter)
        {
            MatrixCoords particlePos = emitterParameter.Position;

            int particleRowSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
            int particleColSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);

            MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

            Particle generated = null;

            int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);
            switch (particleTypeIndex)
            {
                case 0: generated = new Particle(particlePos, particleSpeed); break;
                case 1:
                    uint lifespan = (uint)emitterParameter.RandomGenerator.Next(8);
                    generated = new DyingParticle(particlePos, particleSpeed, lifespan);
                    break;
                default:
                    throw new Exception("No such particle for this particleTypeIndex");
            }
            return generated;
        }
    }
}
