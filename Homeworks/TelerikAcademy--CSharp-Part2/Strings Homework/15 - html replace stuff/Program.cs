using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _15___html_replace_stuff
{
    class Program
    {
        static string ReplaceTags(string str)
        {
            string result = Regex.Replace(str, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]");
            return result;
        }

        static void Main(string[] args)
        {
            string str = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
            Console.WriteLine(str + "\n\n");

            string result = ReplaceTags(str);

            Console.WriteLine(result + "\n\n");
        }
    }
}
