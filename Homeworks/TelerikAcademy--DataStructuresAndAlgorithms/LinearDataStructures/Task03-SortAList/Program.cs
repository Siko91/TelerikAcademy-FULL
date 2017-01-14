using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01_StoreValuesInList;

namespace Task03_SortAList
{
    internal class Program
    {
        /*
         * Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.
         */

        private static void Main(string[] args)
        {
            List<int> numbers = Task01_StoreValuesInList.Program.ReadNumbers();

            numbers.Sort();
            Console.WriteLine("---------------------");
            Console.WriteLine(string.Join("\n", numbers));
        }
    }
}