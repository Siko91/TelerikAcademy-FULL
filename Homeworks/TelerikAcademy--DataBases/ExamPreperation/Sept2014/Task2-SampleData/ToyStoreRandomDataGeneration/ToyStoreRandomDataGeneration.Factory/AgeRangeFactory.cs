using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStoreRandomDataGeneration.Data;

namespace ToyStoreRandomDataGeneration.Factory
{
    public class AgeRangeFactory : IAgeRangeFactory
    {
        public ICollection<AgeRange> Make101AgeRanges()
        {
            List<AgeRange> ranges = new List<AgeRange>();
            for (int st = 0; st < 20; st++)
            {
                for (int end = st + 1; end <= st + 5; end++)
                {
                    ranges.Add(new AgeRange()
                    {
                        RangeFrom = st,
                        RangeTo = end
                    });
                }
            }
            ranges.Add(new AgeRange()
            {
                RangeFrom = 1,
                RangeTo = 101
            });

            return ranges;
        }
    }
}