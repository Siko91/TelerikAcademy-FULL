using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;

namespace XMLQueries.Queries
{
    internal class IdQuery : Query<int>
    {
        /*
        •	Id (number) -> Equals, GreaterThan, LessThan
         */

        public IdQuery(QueryCheckType checkType, int valueToSearchFor)
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

        protected override Dictionary<int, CodeFirst.Models.Car> GetValuesToCheck(IEnumerable<Car> cars)
        {
            Dictionary<int, CodeFirst.Models.Car> values = new Dictionary<int, CodeFirst.Models.Car>();
            foreach (Car car in cars)
            {
                values.Add(car.Id, car);
            }
            return values;
        }
    }
}