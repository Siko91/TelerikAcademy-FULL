using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _04___Compare_files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader1 = new StreamReader(@"..\..\04-First.txt");
            StreamReader reader2 = new StreamReader(@"..\..\04-Second.txt");

            int lines1 = 0;
            int lines2 = 0;

            int equal = 0;
            int different = 0;
            int uncomparable = 0;

            string lineFrom1 = reader1.ReadLine();
            string lineFrom2 = reader2.ReadLine();

            while (lineFrom1 != null || lineFrom2 != null)
            {
                if (lineFrom1 != null ^ lineFrom2 != null)
                    uncomparable++;
                else if (lineFrom1.Equals(lineFrom2))
                    equal++;
                else
                    different++;

                if (lineFrom1 != null)
                {
                    lines1++;
                    lineFrom1 = reader1.ReadLine();
                }   
                if (lineFrom2 != null)
                {
                    lines2++;
                    lineFrom2 = reader2.ReadLine();
                }
            }

            Console.WriteLine("File 1 lines = " + lines1 + "\nFile 2 lines = " + lines2 + "\n\n");
            Console.WriteLine("Equal lines: " + equal + "\nDifferent lines: " + different + "\nUncomparable lines: " + uncomparable + "\n");
        }
    }
}
