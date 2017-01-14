using System;
using System.Linq;

using DefensivePrograming.Assertions;
using DefensivePrograming.Exceptions;

namespace DefensivePrograming
{
    class Program
    {
        static void Main(string[] args)
        {
            AssertionTest.RunTest();
            Console.WriteLine("\n\n---------------------------------------------\n\n");
            ExceptionTest.RunTest();
        }
    }
}
