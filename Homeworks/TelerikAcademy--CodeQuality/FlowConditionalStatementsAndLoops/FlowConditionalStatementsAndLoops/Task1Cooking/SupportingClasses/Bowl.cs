using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowConditionalStatementsAndLoops.Task1Cooking.SupportingClasses
{
    class Bowl
    {
        private List<Vegetable> vegetablesInBowl = new List<Vegetable>();

        public List<Vegetable> VegetablesInBowl
        {
            get { return this.vegetablesInBowl; }
        }

        public void Add(Vegetable vegetable)
        {
            this.vegetablesInBowl.Add(vegetable);
        }
    }
}
