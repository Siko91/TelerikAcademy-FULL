using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _10___extract_from_xml
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter create = new StreamWriter(@"..\..\10-File.xml"))
            {
                create.WriteLine("<?xml version=\"1.0\"><student><name> Pesho</name> ()<age> 21</age><interests count=\"3\"> - <interest> Games</instrest><interest> C#</instrest><interest> Java</instrest></interests></student>");
            }
            using (StreamReader read = new StreamReader(@"..\..\10-File.xml"))
            {
                StringBuilder text = new StringBuilder();
                string line = read.ReadLine();
                bool isTag = false;

                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line.Substring(i, 1).Equals("<") && !isTag)
                        { isTag = true; }
                        else if (line.Substring(i, 1).Equals(">") && isTag)
                        { isTag = false; }
                        else if (!isTag)
                        { text.Append(line.Substring(i, 1)); }
                    }
                    line = read.ReadLine();
                }
                Console.WriteLine(text);
            }
        }
    }
}
