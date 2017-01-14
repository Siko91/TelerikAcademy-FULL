using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.Accuracy = 0.00000000000001;
            Console.WriteLine(Test.TestShapes(5000));
        }
    }
}
