using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var filler = new ToyStoreDbFiller(new ConsoleLogger());

            filler.FillCountries(new Entities());
            filler.FillCategories(new Entities());
            filler.FillAgeRanges(new Entities());
            filler.FillManufacturers(new Entities());

            for (int i = 0; i < 100; i++)
            {
                filler.Fill201Toys(new Entities());
            }
        }
    }
}