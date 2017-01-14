using System.Collections.Generic;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public interface ICountryFactory
    {
        ICollection<Country> Make51Countries();
    }
}