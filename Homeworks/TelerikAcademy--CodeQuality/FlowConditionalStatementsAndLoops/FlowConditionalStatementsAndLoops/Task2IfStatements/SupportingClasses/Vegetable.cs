using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowConditionalStatementsAndLoops.Task2IfStatements.SupportingClasses
{
    class Vegetable
    {
        private bool isRotten = false;
        private bool isPealed = false;
        private bool isCut = false;

        public Vegetable()
        {
        }

        public bool IsRotten
        {
            get { return this.isRotten; }
        }
        public bool IsPealed
        {
            get { return this.isPealed; }
        }
        public bool IsCut
        {
            get { return this.isCut; }
        }

        public void Rot()
        {
            isRotten = true;
        }

        public void Peel()
        {
            isPealed = true;
        }

        public void Cut()
        {
            if (isPealed && !isRotten)
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
