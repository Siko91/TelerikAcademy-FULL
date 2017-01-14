using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CodeFirst.Data;
using CodeFirst.Models;
using XMLQueries.Queries;

namespace XMLQueries
{
    internal class GetQueries
    {
        public static void Main()
        {
            CarsDbContext db = new CarsDbContext();
            XElement queriesFile = XElement.Load("..\\..\\query.xml");

            // no time to fix this little thing. Please - look around and see the bigger picture
            foreach (var query in queriesFile.Element("Queries").Elements("Query"))
            {
                MakeXmlQuery(query, db);
            }
        }

        private static void FilterTheCarsByClause(XElement clause, IEnumerable<Car> cars)
        {
            switch (clause.Attributes().First(a => a.Name == "PropertyName").Value.ToLowerInvariant())
            {
                case "id":
                    cars = new IdQuery(GetCheckType(clause), int.Parse(clause.Value)).Execute(cars);
                    break;

                case "year":
                    cars = new YearQuery(GetCheckType(clause), int.Parse(clause.Value)).Execute(cars);
                    break;

                case "price":
                    cars = new PriceQuery(GetCheckType(clause), decimal.Parse(clause.Value)).Execute(cars);
                    break;

                case "model":
                    cars = new ModelQuery(GetCheckType(clause), clause.Value).Execute(cars);
                    break;

                case "manufacturer":
                    cars = new ManufacturerQuery(GetCheckType(clause), clause.Value).Execute(cars);
                    break;

                case "dealer":
                    cars = new DealerQuery(GetCheckType(clause), clause.Value).Execute(cars);
                    break;

                case "city":
                    cars = new CityQuery(GetCheckType(clause), clause.Value).Execute(cars);
                    break;

                default:
                    break;
            }
        }

        private static QueryCheckType GetCheckType(XElement clause)
        {
            switch (clause.Attributes().First(a => a.Name == "Type").Value)
            {
                case "GreaterThan":
                    return QueryCheckType.GreaterThan;
                    break;

                case "LessThan":
                    return QueryCheckType.LessThan;
                    break;

                case "Equals":
                    return QueryCheckType.Equals;
                    break;

                case "Contains":
                    return QueryCheckType.Contains;
                    break;

                default:
                    break;
            }
            throw new ArgumentException();
        }

        private static void MakeXmlQuery(XElement query, CarsDbContext db)
        {
            string path = "..\\..\\output\\" + query.Attributes().First(a => a.Name == "OutputFileName").Value;
            List<Car> cars = db.Cars.ToList();
            foreach (var clause in query.Element("WhereClauses").Elements("WhereClause"))
            {
                FilterTheCarsByClause(clause, cars);
            }
            WriteToFile(path, cars);
        }

        private static void WriteToFile(string path, List<Car> cars)
        {
            Console.WriteLine("Not Enough time!!!!");
        }
    }
}