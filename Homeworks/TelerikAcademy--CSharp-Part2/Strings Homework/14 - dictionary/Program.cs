using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

struct Translation
{
    public string word;
    public string meaning;
}

class Program
{
    static char[] signs = { ' ', '!', '.', '?', ',', '\n', '\r' };
    static string str = @" It's Friday, Friday
 Gotta get down on Friday
 Everybody's lookin' forward to the weekend, weekend
 Friday, Friday
 Gettin' down on Friday
 Everybody's lookin' forward to the weekend

 Partyin', partyin' (Yeah)
 Partyin', partyin' (Yeah)
 Fun, fun, fun, fun
 Lookin' forward to the weekend

 Yesterday was Thursday, Thursday
 Today i-is Friday, Friday (Partyin')
 We-we-we so excited
 We so excited
 We gonna have a ball today

 Tomorrow is Saturday
 And Sunday comes after ... wards
 I don't want this weekend to end";


    static void Main(string[] args)
    {
        Console.WriteLine("Don't take it too seriously. This is simply a joke. Have fun.\n");

        List<Translation> dictionary = new List<Translation>();

        for (int i = 0; i < 7; i++)
        {
            DateTime day = DateTime.Today.AddDays(i);

            Translation transl = new Translation();
            transl.word = day.DayOfWeek.ToString();
            if (day.DayOfWeek.ToString().Equals("Friday"))
            {
                transl.meaning = ("Fun, fun, fun, fun.");
            }
            else
            {
                transl.meaning = ("Just a day of the week. It's the " + i + "th day from today.");
            }
            dictionary.Add(transl);
            //Console.WriteLine(transl.word + " - " + transl.meaning);
        }
        Console.WriteLine();

        string[] words = str.Split(signs, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("Text:\n\n" + str + "\n\n");

        for (int i = 0; i < words.Length; i++)
        {
            for (int y = 0; y < dictionary.Count(); y++)
            {
                if (words[i].Equals(dictionary[y].word))
                {
                    Console.WriteLine(dictionary[y].word + " - " + dictionary[y].meaning);
                }
            }
        }
        Console.WriteLine();
    }
}
