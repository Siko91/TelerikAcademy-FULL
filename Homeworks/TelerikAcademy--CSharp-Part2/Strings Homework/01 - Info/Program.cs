using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static string str = "This is my string";
    static string num = "444";

    static void Main(string[] args)
    {
        int number = 0;
        Console.WriteLine("Basicly... string is an array of chars. I guess that's all...\n\n");

        Console.WriteLine(num + " is .All(c => c == '4') : " + (num.All(c => c == '4')));
        Console.WriteLine(str + " has .Any(c => c == 'i') : " + str.Any(c => c == 'i'));
        Console.WriteLine(str + ".CompareTo(num) : " + str.CompareTo(num));
        Console.WriteLine(string.Concat(num, str) + " = concated strings (slow).");
        Console.WriteLine(str + " .Contains(\"is\") : " + str.Contains("is"));
        Console.WriteLine(str + " .Equals(\"false\") : " + str.Equals("false"));
        Console.WriteLine(str + " .IndexOf(\"is\") : " + str.IndexOf("is"));
        Console.WriteLine(str + " .Insert(0, \"is\") : " + str.Insert(0, "is"));
        Console.WriteLine("Using string.Join(\" - \", str, num) : " + string.Join(" - ", str, num));
        Console.WriteLine(str + " .LastIndexOf('i') : " + str.LastIndexOf('i'));
        Console.WriteLine(str + " .Length : " + str.Length);
        Console.WriteLine(str + " .PadLeft(30) : " + str.PadLeft(30));
        Console.WriteLine(str + " .Reverse() : " + string.Join("", str.Reverse()));
        Console.WriteLine(str + " .Split(' ') : " + string.Join("/", str.Split(' ')));
        Console.WriteLine(str + " .Substring(5) : " + str.Substring(5));
        Console.WriteLine(str + " .ToCharArray() : " + string.Join("/", str.ToCharArray()));
        Console.WriteLine(str + " .ToUpper() : " + str.ToUpper());
        Console.WriteLine(str + " .TrimStart('T') : " + str.TrimStart('T'));
        Console.WriteLine(num + " int.Parse(num) : " + int.Parse(num));
        Console.WriteLine(num + " int.TryParse(num, out number) : " + int.TryParse(num, out number));

        Console.WriteLine();
    }
}
