using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Data;
using CodeFirst.Models;

namespace XMLQueries
{
    public abstract class Query<T> where T : IComparable
    {
        public Query(QueryCheckType checkType, T valueToSearchFor)
        {
            this.CheckType = checkType;
            this.ValueToSearch = valueToSearchFor;
        }

        public virtual QueryCheckType CheckType
        {
            get
            {
                return this.checkType;
            }

            set
            {
                if (!this.ValidChecks.Contains(value))
                {
                    throw new ArgumentException("Invalid check type");
                }
                this.checkType = value;
            }
        }

        public abstract IEnumerable<QueryCheckType> ValidChecks { get; }

        public virtual IEnumerable<Car> Execute(IEnumerable<Car> cars)
        {
            Dictionary<T, Car> valuesToCheck = GetValuesToCheck(cars);

            List<Car> resultCars = new List<Car>();
            switch (this.CheckType)
            {
                case QueryCheckType.Equals:
                    foreach (T key in valuesToCheck.Keys)
                    {
                        if (key.Equals(this.ValueToSearch))
                        {
                            resultCars.Add(valuesToCheck[key]);
                        }
                    }
                    break;

                case QueryCheckType.GreaterThan:
                    foreach (var key in valuesToCheck.Keys)
                    {
                        if (key.CompareTo(this.ValueToSearch) >= 1)
                        {
                            resultCars.Add(valuesToCheck[key]);
                        }
                    }
                    break;

                case QueryCheckType.LessThan:
                    foreach (var key in valuesToCheck.Keys)
                    {
                        if (key.CompareTo(this.ValueToSearch) <= -1)
                        {
                            resultCars.Add(valuesToCheck[key]);
                        }
                    }
                    break;

                default:
                    break;
            }
            return resultCars;
        }

        protected virtual T ValueToSearch { get; set; }

        protected abstract Dictionary<T, Car> GetValuesToCheck(IEnumerable<Car> cars);

        private QueryCheckType checkType;
    }
}