using System.Collections.Generic;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public interface IToyFactory
    {
        ICollection<Toy> Make100Toys(int[] ageRangeIds, int[] manufacturerIds);

        Toy Make1Toy(int[] ageRangeIds, int[] manufacturerIds);
    }
}