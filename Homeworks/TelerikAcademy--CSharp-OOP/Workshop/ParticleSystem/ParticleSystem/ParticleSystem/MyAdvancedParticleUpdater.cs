using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    class MyAdvancedParticleUpdater : ParticleUpdater
    {
        private List<PartivleReppeler> currentReppelers = new List<PartivleReppeler>();
        private List<Particle> currentParticles = new List<Particle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            IEnumerable<Particle> newList = p.Update();

            currentParticles.Add(p);
            if (p is PartivleReppeler)
            {
                currentReppelers.Add((PartivleReppeler)p);
            }
            return newList;
        }
        public override void TickEnded()
        {
            foreach (PartivleReppeler repeler in currentReppelers)
            {
                foreach (Particle item in currentParticles)
                {
                    if (repeler.RepelRadius < 
                        Math.Sqrt(
                            Math.Pow((item.Position.Row - repeler.Position.Row), 2) +
                            Math.Pow((item.Position.Col - repeler.Position.Col), 2)
                            )
                        )
                    {
                        continue;
                    }
                    var currAcceleration = GetAccelerationFromReppelerToParticle(repeler, item);

                    item.Accelerate(currAcceleration);
                }
            }

            currentParticles.Clear();
            currentReppelers.Clear();
        }
        private static MatrixCoords GetAccelerationFromReppelerToParticle(PartivleReppeler repeler, Particle particle)
        {
            var currParticleToAttractorVector = particle.Position - repeler.Position;

            int pToAttrRow = currParticleToAttractorVector.Row;
            pToAttrRow = DecreaseVectorCoordToPower(repeler, pToAttrRow);

            int pToAttrCol = currParticleToAttractorVector.Col;
            pToAttrCol = DecreaseVectorCoordToPower(repeler, pToAttrCol);

            var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);
            return currAcceleration;
        }
        private static int DecreaseVectorCoordToPower(PartivleReppeler attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.Power)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * attractor.Power;
            }
            return pToAttrCoord;
        }
    }
}
