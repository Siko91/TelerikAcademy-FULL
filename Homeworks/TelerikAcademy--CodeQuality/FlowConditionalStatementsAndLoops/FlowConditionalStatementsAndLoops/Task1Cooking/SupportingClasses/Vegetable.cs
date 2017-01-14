using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowConditionalStatementsAndLoops.Task1Cooking.SupportingClasses
{
    class Vegetable
    {
        private bool isPealed = false;
        private bool isCut = false;

        public Vegetable()
        {
        }

        public void Peel()
        {
            isPealed = true;
        }

        public void Cut()
        {
            if (isPealed)
            {
                isCut = true;
            }
        }

        public bool IsReady()
        {
            return isCut;
        }
    }
}
