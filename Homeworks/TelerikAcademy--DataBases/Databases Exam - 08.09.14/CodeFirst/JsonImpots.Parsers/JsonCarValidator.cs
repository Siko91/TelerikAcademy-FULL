using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Data;
using CodeFirst.Models;

namespace JsonImports.Parsers
{
    public class JsonCarValidator
    {
        public void CheckAllCars(ICollection<Car> cars, CarsDbContext db)
        {
            int counter = 0;
            foreach (var car in cars)
            {
                counter++;
                if (counter % 100 == 0)
                {
                    Console.WriteLine("100 cars parsed");
                }
                this.ReplaceManufacturerIfItExists(car, db);
                this.ReplaceCityIfItExists(car, db);
            }
        }

        private void ReplaceCityIfItExists(Car car, CarsDbContext db)
        {
            var matchingCity = db.Cities.FirstOrDefault(c => c.Name == car.Dealer.City.Name);
            if (matchingCity != null)
            {
                car.Dealer.City = matchingCity;
            }
            else
            {
                db.Cities.Add(car.Dealer.City);
            }
        }

        private void ReplaceManufacturerIfItExists(Car car, CarsDbContext db)
        {
            var matchingManufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == car.Manufacturer.Name);
            if (matchingManufacturer != null)
            {
                car.Manufacturer = matchingManufacturer;
            }
            else
            {
                db.Manufacturers.Add(car.Manufacturer);
            }
        }
    }
}