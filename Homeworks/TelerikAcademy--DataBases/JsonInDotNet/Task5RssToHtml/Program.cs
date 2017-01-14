using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5JsonToPoco;

namespace Task6RssToHtml
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var items = JsonToPoco.ParseRootOfRss("..\\..\\Result.json").rss.channel.item;
            FileStream stream = new FileStream("..\\..\\WebPage.html", FileMode.Create);
            using (StreamWriter writter = new StreamWriter(stream, Encoding.Unicode))
            {
                writter.WriteLine("<!DOCTYPE HTML>");
                writter.WriteLine("<html>");
                writter.WriteLine("<head><link rel='stylesheet' type='text/css' href='styles.css'><title>Recent Questions</title></head>");
                writter.WriteLine("<body>");

                writter.WriteLine("<table><thead><tr style='background: lightgreen; font-weight: bolder;'>" +
                    "<td>Title</td>" +
                    "<td>Category</td>" +
                    "<td>Link</td></thead>");

                foreach (var item in items)
                {
                    writter.WriteLine("<tr><td>" + item.title + "</td>" +
                                    "<td>" + item.category + "</td>" +
                                    "<td>" + item.link + "</td></tr>");
                }

                writter.WriteLine("</tr></thead></table>");
                writter.WriteLine("/<body>");
                writter.WriteLine("</html>");
            }
        }
    }
}