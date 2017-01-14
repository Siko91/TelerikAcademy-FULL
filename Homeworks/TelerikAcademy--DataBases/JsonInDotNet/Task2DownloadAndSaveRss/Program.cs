using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Task2DownloadAndSaveRss
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri("http://forums.academy.telerik.com/feed/qa.rss"), "..\\..\\DownloadedFile.xml");
            }
        }
    }
}