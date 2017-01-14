using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _09___delete_odd_lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter create = new StreamWriter(@"..\..\09-File.txt"))
            {
                for (int i = 1; i <= 100; i++)
                {
                    create.WriteLine(i);
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("\n\n\nRemoving odd lines from [ ..\\..\\09-File.txt ]\n");
            List<string> list = new List<string>();

            using (StreamReader read = new StreamReader(@"..\..\09-File.txt"))
            {
                string line = read.ReadLine();
                while (line!=null)
	            {
                    list.Add(line);
                    line = read.ReadLine();
	            }
            }
            using (StreamWriter write = new StreamWriter(@"..\..\09-File.txt"))
            {
                for (int i = 1; i <= list.Count(); i++)
                {
                    if (i%2==0)
                    {
                        write.WriteLine(list[i-1]);
                    }
                }
            }
        }
    }
}
