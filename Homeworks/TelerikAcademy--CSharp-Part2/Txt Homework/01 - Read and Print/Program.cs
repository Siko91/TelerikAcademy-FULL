using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _01___Read_and_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\01-TextFile.txt");

            string temp = "";
            int line = 0;

            temp = reader.ReadLine();
            while (temp != null)
            {
                if (line % 2 == 1)
                    Console.WriteLine("Line {0}:    {1}", line, temp);

                line++;
                temp = reader.ReadLine();
            }
            reader.Dispose();
        }
    }
}
