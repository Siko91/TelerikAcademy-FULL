using System.Collections.Generic;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public interface IToyCategoryFactory
    {
        ICollection<Category> Make101ToyCategories();
    }
}