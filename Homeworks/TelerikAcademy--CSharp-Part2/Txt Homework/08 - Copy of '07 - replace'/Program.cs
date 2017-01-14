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
            StreamReader read = new StreamReader(@"..\..\08-TextFile.txt");
            StreamWriter write = new StreamWriter(@"..\..\08-Replaced.txt");

            char[] specialChars = { ' ', '.', ',', '!', '?', ';', ':', '\'', '\"' };
            string start = "start";

            //Console.WriteLine("{0,25}     |{1,13}|{2,13}|{3,10}", "string", "bool", "bool", "int");
            //Console.WriteLine("{0,25}     |{1,13}|{2,13}|{3,10}", "Line", "startIsFine", "endIsFine", "index");
            //Console.WriteLine("-----------------------------------------------------------------------");

            string line = read.ReadLine();
            while (line != null)
            {
                int index = line.IndexOf(start, 0, StringComparison.CurrentCultureIgnoreCase);
                
                while (index >= 0)
                {
                    bool isUpper = false;
                    if (line.Substring(index, 1).Equals("S"))
                        isUpper = true;

                    bool startIsFine = false, endIsFine = false;

                    if (index > 0)
                    {
                        for (int i = 0; i < specialChars.Length; i++)
                        {
                            if (line.Substring(index - 1, 1).Equals(specialChars[i].ToString()))
                            {
                                startIsFine = true;
                                break;
                            }
                        }
                    }
                    else
                    { startIsFine = true; }

                    if (index < line.Length - 1)
                    {
                        for (int i = 0; i < specialChars.Length; i++)
                        {
                            if (line.Substring(index + start.Length, 1).Equals(specialChars[i].ToString()))
                            {
                                endIsFine = true;
                                break;
                            }
                        }
                    }
                    else
                        endIsFine = true;

                    //Console.WriteLine("{0,30}|{1,13} {2,13} {3,10}", line, startIsFine, endIsFine, index);

                    if (startIsFine && endIsFine)
                    {
                        string finish = "finish";
                        if (isUpper) finish = "Finish";
                        line = line.Substring(0, index) + finish + line.Substring(index + start.Length);
                    }
                    
                    index = line.IndexOf(start, index+1, StringComparison.CurrentCultureIgnoreCase);
                }

                //Console.WriteLine("Replacing...{0," + (31-"Replacing...".Length) + "}\n{1,30}|", "|", line);
                //Console.WriteLine("-----------------------------------------------------------------------");
                write.WriteLine(line);
                line = read.ReadLine();
            }

            read.Dispose();
            write.Dispose();
        }
    }
}