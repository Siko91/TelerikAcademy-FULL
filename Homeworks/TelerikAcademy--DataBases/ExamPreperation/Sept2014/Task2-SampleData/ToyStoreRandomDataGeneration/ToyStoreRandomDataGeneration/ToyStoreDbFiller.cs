using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStoreRandomDataGeneration.Data;
using ToyStoreRandomDataGeneration.Factory;

namespace ToyStoreRandomDataGeneration
{
    internal class ToyStoreDbFiller
    {
        public ToyStoreDbFiller(ILogger logger)
        {
            this.logger = logger;
        }

        public void Fill201Toys(Entities db)
        {
            int[] manufIds = db.Manufacturers.Select(m => m.Id).ToArray();
            int[] ageRangeIds = db.AgeRanges.Select(ar => ar.Id).ToArray();

            for (int i = 0; i < 2; i++)
            {
                var toys = new ToyFactory().Make100Toys(ageRangeIds, manufIds);
                foreach (var toy in toys)
                {
                    db.Toys.Add(toy);
                }
            }
            db.Toys.Add(new ToyFactory().Make1Toy(ageRangeIds, manufIds));
            db.SaveChanges();
            logger.Log("201 toys added. Toys are now " + db.Toys.Count());
        }

        public void FillAgeRanges(Entities db)
        {
            var ranges = new AgeRangeFactory().Make101AgeRanges();
            foreach (var range in ranges)
            {
                db.AgeRanges.Add(range);
            }
            db.SaveChanges();
            logger.Log("101 age ranges added");
        }

        public void FillCategories(Entities db)
        {
            var categories = new ToyCategoryFactory().Make101ToyCategories();
            foreach (var cat in categories)
            {
                db.Categories.Add(cat);
            }
            db.SaveChanges();
            logger.Log("101 categories added");
        }

        public void FillCountries(Entities db)
        {
            var countries = new CountryFactory().Make51Countries();
            foreach (var country in countries)
            {
                db.Countries.Add(country);
            }
            db.SaveChanges();
            logger.Log("51 countries added");
        }

        public void FillManufacturers(Entities db)
        {
            var manufacturers = new ManufacturerFactory().Make51Manufacturers(db.Countries.Select(c => c.Id).ToArray());
            foreach (var manuf in manufacturers)
            {
                db.Manufacturers.Add(manuf);
            }
            db.SaveChanges();
            logger.Log("51 manufacturers added");
        }

        private ILogger logger;
    }
}