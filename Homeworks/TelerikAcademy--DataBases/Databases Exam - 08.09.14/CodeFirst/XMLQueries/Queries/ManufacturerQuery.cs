using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;

namespace XMLQueries.Queries
{
    internal class ManufacturerQuery : Query<string>
    {
        /*
        •	Manufacturer (its name, text) -> Equals, Contains
         */

        public ManufacturerQuery(QueryCheckType checkType, string valueToSearchFor)
            : base(checkType, valueToSearchFor)
        {
        }

        public override IEnumerable<QueryCheckType> ValidChecks
        {
            get
            {
                return new List<QueryCheckType>()
                    {
                        QueryCheckType.Equals,
                        QueryCheckType.Contains
                    };
            }
        }

        public override IEnumerable<Car> Execute(IEnumerable<Car> cars)
        {
            if (this.CheckType.Equals(QueryCheckType.Contains))
            {
                Dictionary<string, Car> valuesToCheck = GetValuesToCheck(cars);
                List<Car> resultCars = new List<Car>();
                foreach (var key in valuesToCheck.Keys)
                {
                    if (key.Contains(this.ValueToSearch))
                    {
                        resultCars.Add(valuesToCheck[key]);
                    }
                }
                return resultCars;
            }

            return base.Execute(cars);
        }

        protected override Dictionary<string, CodeFirst.Models.Car> GetValuesToCheck(IEnumerable<Car> cars)
        {
            Dictionary<string, CodeFirst.Models.Car> values = new Dictionary<string, CodeFirst.Models.Car>();
            foreach (Car car in cars)
            {
                values.Add(car.Manufacturer.Name, car);
            }
            return values;
        }
    }
}