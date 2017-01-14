using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleDataFiller.Filler
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}