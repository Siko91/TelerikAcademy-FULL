using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowConditionalStatementsAndLoops.Task3Loop
{
    class Loop
    {
        public void Run()
        {
            int[] array = new int[100];

            int expectedValue = -1;
            array[60] = expectedValue;

            bool valueFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + ", ");

                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        valueFound = true;
                    }
                }
            }

            if (valueFound)
            {
                Console.WriteLine("\nValue Found");
            }
        }
    }
}
