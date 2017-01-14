using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6UsageOfHashedSet
{
    public class Human
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Town { get; set; }

        public override string ToString()
        {
            return this.Name + " | " + this.Town + " | " + this.PhoneNumber;
        }
    }
}