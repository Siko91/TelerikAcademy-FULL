using System.Collections.Generic;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public interface IAgeRangeFactory
    {
        ICollection<AgeRange> Make101AgeRanges();
    }
}