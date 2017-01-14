using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static string str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
    static string keyWord = "in";

    static void Main(string[] args)
    {
        int result = 0;
        int index = str.IndexOf(keyWord, 0, StringComparison.InvariantCultureIgnoreCase);

        while (index != -1)
        {
            result++;
            index = str.IndexOf(keyWord, index + 1, StringComparison.InvariantCultureIgnoreCase);
        }
        Console.WriteLine("Text:\n" + str + "\n");
        Console.WriteLine("Word:\n" + keyWord + "\n");
        Console.WriteLine(result + " times.");
    }
}
