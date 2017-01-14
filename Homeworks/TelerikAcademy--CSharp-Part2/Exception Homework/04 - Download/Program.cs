using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

class Program
{
    static string pathToFile = @"http://mail.bg/images/mail.bg_15_small.png";

    static string downloadDirectory = @"..\..\Image.jpg";

    static void Main(string[] args)
    {
        WebClient wc = new WebClient();
        try
        {
            Uri link = new Uri(pathToFile);
            wc.DownloadFile(link, downloadDirectory);
        }
        catch (WebException)
        { Console.WriteLine("An error occured while accesing the network."); }
        catch (NotSupportedException)
        { Console.WriteLine("Operation not supported."); }
        catch (ArgumentNullException)
        { Console.WriteLine("Missing URL or FileName."); }
        catch (UriFormatException)
        { Console.WriteLine("Invalid URL."); }
        finally
        {
            wc.Dispose();
        }
    }
}
