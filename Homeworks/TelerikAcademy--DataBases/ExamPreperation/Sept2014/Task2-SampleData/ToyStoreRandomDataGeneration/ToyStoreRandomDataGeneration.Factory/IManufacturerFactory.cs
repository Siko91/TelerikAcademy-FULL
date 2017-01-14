using System.Collections.Generic;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public interface IManufacturerFactory
    {
        ICollection<Manufacturer> Make51Manufacturers(int[] countryIds);
    }
}