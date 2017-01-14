using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public class ToyFactory : IToyFactory
    {
        public ToyFactory()
        {
            this.rand = RandomGen.Instance;
        }

        public ICollection<Toy> Make100Toys(int[] ageRangeIds, int[] manufacturerIds)
        {
            Toy[] toys = new Toy[100];
            for (int i = 0; i < 100; i++)
            {
                toys[i] = this.Make1Toy(ageRangeIds, manufacturerIds);
            }
            return toys;
        }

        public Toy Make1Toy(int[] ageRangeIds, int[] manufacturerIds)
        {
            return new Toy()
            {
                Name = this.rand.RandomString(20),
                Type = this.rand.RandomString(10),
                AgeRange = ageRangeIds[this.rand.RandomNum(ageRangeIds.Length)],
                Manufacturer = manufacturerIds[this.rand.RandomNum(manufacturerIds.Length)],
                Price = this.rand.RandomPrice(0, 100),
            };
        }

        private RandomGen rand;
    }
}