using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FlowConditionalStatementsAndLoops.Task2IfStatements.SupportingClasses;

namespace FlowConditionalStatementsAndLoops.Task2IfStatements
{
    class IfStatements
    {
        Potato potato = new Potato();
        Chef chef = new Chef();

        const int MIN_X = 0;
        const int MAX_X = 100;
        const int MIN_Y = 0;
        const int MAX_Y = 100;

        public void Run()
        {
            // First If Statement
            if (null != potato)
            {
                if(potato.IsPealed && !potato.IsRotten)
                {
                    chef.Cook(potato);
                }
            }

            // Second If Statement
            int x = 11;
            int y = 10;
            
            bool IsInRangeX = (MIN_X <= x) && (x <= MAX_X);
            bool IsInRangeY = (MIN_Y <= y) && (y <= MAX_Y);
            bool cellAvailable = true;

            bool canVisitCel = IsInRangeX && IsInRangeY && cellAvailable;

            if (canVisitCel)
            {
                VisitCell();
            }
        }

        public void VisitCell() 
        { 
            // Some Code
        }
    }
}