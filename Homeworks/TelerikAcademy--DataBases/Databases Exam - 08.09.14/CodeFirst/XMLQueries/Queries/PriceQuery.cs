using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;

namespace XMLQueries.Queries
{
    internal class PriceQuery : Query<decimal>
    {
        /*
        •	Price (floating point number) -> Equals, GreaterThan, LessThan
         */

        public PriceQuery(QueryCheckType checkType, decimal valueToSearchFor)
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
                        QueryCheckType.GreaterThan,
                        QueryCheckType.LessThan
                    };
            }
        }

        protected override Dictionary<decimal, CodeFirst.Models.Car> GetValuesToCheck(IEnumerable<Car> cars)
        {
            Dictionary<decimal, CodeFirst.Models.Car> values = new Dictionary<decimal, CodeFirst.Models.Car>();
            foreach (Car car in cars)
            {
                values.Add(car.Price, car);
            }
            return values;
        }
    }
}