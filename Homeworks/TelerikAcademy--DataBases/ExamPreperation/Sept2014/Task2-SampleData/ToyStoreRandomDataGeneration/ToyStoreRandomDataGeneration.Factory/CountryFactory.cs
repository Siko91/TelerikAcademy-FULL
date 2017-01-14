using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public class CountryFactory : ICountryFactory
    {
        public ICollection<Country> Make51Countries()
        {
            List<Country> countries = new List<Country>();
            var rand = RandomGen.Instance;
            for (int i = 0; i < 101; i++)
            {
                countries.Add(new Country()
                {
                    Name = rand.RandomString(50)
                });
            }
            return countries;
        }
    }
}