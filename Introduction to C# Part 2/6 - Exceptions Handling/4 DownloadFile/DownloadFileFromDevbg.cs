using System;
using System.Net;

class DownloadFileFromDevbg
{


    static void Main(string[] args)
    {
        string url = "http://www.devbg.org/img/Logo-BASD.jpg";
        WebClient webClient = new WebClient();
        try
        {
            webClient.DownloadFile(url, "logo.jpg");

        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The address was null");
        }
        catch (WebException)
        {
            Console.WriteLine("Invalid URI or error occured while downloading");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads");
        }
    }
}