using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Data;

using CodeFirst.Models;
using JsonImports.Parsers;

namespace JsonImports.Import
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CarsDbContext db = CarsDbContext.WorkingInstance;

            var parser = new JsonCarParser();

            //complete test
            //ICollection<Car> cars = parser.ParseFolder("..\\..\\..\\..\\Data.Json.Files");

            //fast test
            List<Car> cars = new List<Car>();
            parser.AddCarsFromFile(cars, new FileInfo("..\\..\\..\\..\\Data.Json.Files\\data.0.json"));

            Console.WriteLine(cars.Count() + " cars have been loaded");

            // if car city or manufacturer are repeated, the validator will use only the first
            // instance that occures to him
            JsonCarValidator validator = new JsonCarValidator();
            validator.CheckAllCars(cars, db);

            Console.WriteLine(cars.Count() + " cars have been parsed");

            int counter = 0;
            foreach (var car in cars)
            {
                counter++;
                if (counter % 200 == 0)
                {
                    db.SaveChanges();
                    Console.WriteLine("About 200 cars have been added");
                }
                db.Cars.Add(car);
            }
            db.SaveChanges();
            Console.WriteLine("All cars have been added");
        }
    }
}