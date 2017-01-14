using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;
using JsonImports.Parsers.JsonPOCOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonImports.Parsers
{
    public class JsonCarParser
    {
        public void AddCarsFromFile(List<Car> cars, FileInfo file)
        {
            StreamReader re = File.OpenText(file.FullName);
            JsonTextReader reader = new JsonTextReader(re);
            var jsonArr = JArray.Load(reader);
            var jsonCars = JsonConvert.DeserializeObject<JsonCar[]>(jsonArr.ToString());

            foreach (var jCar in jsonCars)
            {
                cars.Add(new Car()
                {
                    Model = jCar.Model,
                    Price = (decimal)jCar.Price,
                    TransmissionType = (TransmissionType)jCar.TransmissionType,
                    Year = jCar.Year,
                    Manufacturer = new Manufacturer()
                    {
                        //check if manufacturer exist will be done in a different class
                        Name = jCar.ManufacturerName
                    },
                    Dealer = new Dealer()
                    {
                        Name = jCar.Dealer.Name,
                        City = new City()
                        {
                            //check if city exist will be done in a different class
                            Name = jCar.Dealer.City
                        }
                    }
                });
            }
        }

        public ICollection<Car> ParseFolder(string path)
        {
            List<Car> cars = new List<Car>();
            if (Directory.Exists(path))
            {
                var dir = new DirectoryInfo(path);
                foreach (var file in dir.GetFiles())
                {
                    if (file.FullName.EndsWith(".json"))
                    {
                        AddCarsFromFile(cars, file);
                    }
                }
            }
            return cars;
        }
    }
}