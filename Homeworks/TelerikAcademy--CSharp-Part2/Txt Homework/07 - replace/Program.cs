using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _07___replace
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader(@"..\..\07-TextFile.txt");
            StreamWriter write = new StreamWriter(@"..\..\07-Replaced.txt");

            string start = "start";
            string finish = "finish";

            string line = read.ReadLine();
            while (line != null)
            {
                int index = line.IndexOf(start, 0, StringComparison.CurrentCultureIgnoreCase);

                while (index >= 0)
                {
                    line = line.Substring(0, index) + finish + line.Substring(index + start.Length);
                    index = line.IndexOf(start, index + 1, StringComparison.CurrentCultureIgnoreCase);
                }
                write.WriteLine(line);
                line = read.ReadLine();
            }

            read.Dispose();
            write.Dispose();
        }
    }
}