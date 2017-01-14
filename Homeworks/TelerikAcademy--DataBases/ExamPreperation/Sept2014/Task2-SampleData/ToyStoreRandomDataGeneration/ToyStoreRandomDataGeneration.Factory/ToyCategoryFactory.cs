using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public class ToyCategoryFactory : IToyCategoryFactory
    {
        public ICollection<Category> Make101ToyCategories()
        {
            var rand = RandomGen.Instance;
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 101; i++)
            {
                categories.Add(new Category()
                {
                    Name = rand.RandomString(50)
                });
            }
            return categories;
        }
    }
}