using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindDBContext;

namespace Task8InheritingEmployee
{
    public class EmployeePlus : Employee
    {
        public EmployeePlus()
        {
            this.CorrespondingTeritories = new EntitySet<Territory>();
            foreach (Territory ter in this.Territories)
            {
                this.CorrespondingTeritories.Add(ter);
            }
        }

        public EntitySet<Territory> CorrespondingTeritories { get; set; }
    }
}