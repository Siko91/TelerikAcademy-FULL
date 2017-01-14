using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;

namespace XMLQueries.Queries
{
    internal class CityQuery : Query<string>
    {
        /*
        •	City (its name) -> Equals
         */

        public CityQuery(QueryCheckType checkType, string valueToSearchFor)
            : base(checkType, valueToSearchFor)
        {
        }

        public override IEnumerable<QueryCheckType> ValidChecks
        {
            get
            {
                return new List<QueryCheckType>()
                    {
                        QueryCheckType.Equals
                    };
            }
        }

        protected override Dictionary<string, CodeFirst.Models.Car> GetValuesToCheck(IEnumerable<Car> cars)
        {
            Dictionary<string, CodeFirst.Models.Car> values = new Dictionary<string, CodeFirst.Models.Car>();
            foreach (Car car in cars)
            {
                values.Add(car.Dealer.City.Name, car);
            }
            return values;
        }
    }
}