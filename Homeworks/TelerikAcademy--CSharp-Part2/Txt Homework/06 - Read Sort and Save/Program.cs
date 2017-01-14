using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace _06___Read_Sort_and_Save
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading...");
            List<string> list = new List<string>();
            
            using (StreamReader reader = new StreamReader(@"..\..\06-Unsorted.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    list.Add(line);
                    line = reader.ReadLine();
                }
            }

            Thread.Sleep(100); // for visual effect :D
            Console.WriteLine("Sorting...");
            list.Sort();

            Thread.Sleep(100); // for visual effect :D
            Console.WriteLine("Writing...");
            using (StreamWriter writer = new StreamWriter(@"..\..\06-Sorted.txt"))
                for (int i = 0; i < list.Count(); i++)
                    writer.WriteLine(list[i]);

            Thread.Sleep(100); // for visual effect :D
            Console.WriteLine("Done!");
        }
    }
}
