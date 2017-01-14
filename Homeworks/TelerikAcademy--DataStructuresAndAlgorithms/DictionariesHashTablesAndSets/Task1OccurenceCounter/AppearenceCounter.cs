using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1OccurenceCounter
{
    public class AppearenceCounter<T>
    {
        public AppearenceCounter(ICollection<T> collection)
        {
            this.Collection = collection;
        }

        public Dictionary<T, int> Appearences { get; set; }

        public ICollection<T> Collection
        {
            get
            {
                return this.collection;
            }

            set
            {
                this.collection = value;
                this.Appearences = this.CountAppearences(this.Collection);
            }
        }

        private ICollection<T> collection;

        private Dictionary<T, int> CountAppearences(ICollection<T> collection)
        {
            Dictionary<T, int> result = new Dictionary<T, int>();
            foreach (T item in collection)
            {
                if (result.ContainsKey(item))
                {
                    result[item]++;
                }
                else
                {
                    result.Add(item, 1);
                }
            }
            return result;
        }
    }
}