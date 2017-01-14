using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03___ReadLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            bool exit = false;

            while (!exit)
            {
                int num = rnd.Next(5000);
                Console.WriteLine("Press [Enter] to restart.\n");
                Console.WriteLine("Number: " + num);
                Console.WriteLine("Word : " + ReadLastDigit(num));
                Console.ReadLine();
                Console.Clear();
            }
        }
        static string ReadLastDigit(int num)
        {
            num = num % 10;

            switch (num)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";

                default: return "Error!";
            }
        }
    }
}
