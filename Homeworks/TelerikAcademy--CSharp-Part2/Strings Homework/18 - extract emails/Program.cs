using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _18___extract_emails
{
    class Program
    {
        static string regexMail = @"((?<=\s)(?<name>[a-zA-Z01-9_\-][a-zA-Z01-9_\-\.]*)@(?<host>[a-zA-Z01-9_\-][a-zA-Z01-9_\-\.]*).(?<domain>[a-zA-Z]{2,4})(?=\s)){1}";

        static string text = @"
            blabla.bla@blaa.Bla.bg <------------------This will matchh
            bla@bla.th <------------------This will matchh
            bla44@vt.ss  <------------------This will matchh
            **@**.bg
            ala-bala@***.jh
            a@a.aa****someText";

        static void Main(string[] args)
        {
            MatchCollection mails = Regex.Matches(text, regexMail);

            Console.Write("{0,20}", "NAME");
            Console.Write("{0,5}", "@");
            Console.Write("{0,20}", "HOST");
            Console.Write("{0,5}", ".");
            Console.WriteLine("{0,8}", "DOMAIN");
            string line = new string('-', 60);
            Console.WriteLine(line);

            foreach (Match mail in mails)
            {
                Console.Write("{0,20}", mail.Groups["name"]);
                Console.Write("{0,5}", "@");
                Console.Write("{0,20}", mail.Groups["host"]);
                Console.Write("{0,7}", ".");
                Console.WriteLine("{0,5}", mail.Groups["domain"]);
            }
        }
    }
}
