using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01___Print_Name_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Whats your name?");
            Console.Write("Name : ");
            string name = Console.ReadLine();

            PrintName(name);
        }
        static void PrintName(string name)
        {
            Console.WriteLine("\nHallo, " + name);
        }
    }
}
