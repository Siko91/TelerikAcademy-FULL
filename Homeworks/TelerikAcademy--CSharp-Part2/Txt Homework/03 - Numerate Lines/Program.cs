using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _03___Numerate_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\03-Read.txt");
            StreamWriter writer = new StreamWriter(@"..\..\03-Write.txt");

            string line = reader.ReadLine();
            int num = 0;

            while (line != null)
            {
                Console.WriteLine("Line " + num + ": " + line);
                writer.WriteLine("Line " + num + ": " + line);

                num++;
                line = reader.ReadLine();
            }

            reader.Dispose();
            writer.Dispose();

        }
    }
}
