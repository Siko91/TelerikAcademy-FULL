using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowConditionalStatementsAndLoops.Task2IfStatements.SupportingClasses
{
    class Chef
    {
        public void Cook(Vegetable vegetable)
        {
            vegetable.Peel();
            vegetable.Cut();
        }
    }
}
