using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12___url
{
    class Program
    {
        static string str = "http://forums.academy.telerik.com/categories";

        static void Main(string[] args)
        {
            int endOfProtocol = str.IndexOf("://");
            int endOfServer = str.IndexOf("/", str.IndexOf("."));
            string[] url = new string[3];
            url[0] = str.Substring(0, endOfProtocol);
            url[1] = str.Substring(endOfProtocol + 3, endOfServer - (endOfProtocol + 3));
            url[2] = str.Substring(endOfServer);

            for (int i = 0; i < url.Length; i++)
            {
                Console.WriteLine("{0}",url[i]);
            }
            Console.WriteLine();

        }
    }
}
