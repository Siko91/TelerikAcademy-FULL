using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public class ManufacturerFactory : IManufacturerFactory
    {
        public ICollection<Manufacturer> Make51Manufacturers(int[] countryIds)
        {
            var rand = RandomGen.Instance;
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            for (int i = 0; i < 51; i++)
            {
                manufacturers.Add(new Manufacturer()
                {
                    Name = rand.RandomString(45) + i,
                    Country = countryIds[rand.RandomNum() % countryIds.Length]
                });
            }
            return manufacturers;
        }
    }
}