using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractText
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\File.html");
        using (reader)
        {
            string line = string.Empty;
            MatchCollection matchProtocolAndSiteName;

            while ((line = reader.ReadLine()) != null)
            {
                matchProtocolAndSiteName = Regex.Matches(line, @"(?<=^|>)[^><]+?(?=<|$)");

                foreach (var word in matchProtocolAndSiteName)
                    Console.WriteLine(word);
            }
        }
    }
}