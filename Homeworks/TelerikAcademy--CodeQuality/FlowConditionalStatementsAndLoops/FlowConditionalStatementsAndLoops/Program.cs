using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FlowConditionalStatementsAndLoops.Task1Cooking;
using FlowConditionalStatementsAndLoops.Task2IfStatements;
using FlowConditionalStatementsAndLoops.Task3Loop;

namespace FlowConditionalStatementsAndLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1 - Nothing to print
            Chef chef = new Chef();
            chef.Cook();

            // Task 2 - Nothing to print
            IfStatements ifs = new IfStatements();
            ifs.Run();

            // Task 3 - Prints some numbers
            Loop loop = new Loop();
            loop.Run();
        }
    }
}
