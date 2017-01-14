using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace _02___Concat_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader(@"..\..\02-First.txt");
            string first = reader1.ReadToEnd();
            reader1.Dispose();

            StreamReader reader2 = new StreamReader(@"..\..\02-Second.txt");
            string second = reader2.ReadToEnd();
            reader2.Dispose();

            StreamWriter writer = new StreamWriter(@"..\..\02-Final.txt");
            writer.Write(first + second);
            writer.Dispose();

            Console.WriteLine("Text saved:\n\n" + first + second + "\n\n");
        }
    }
}
