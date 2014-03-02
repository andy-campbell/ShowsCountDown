using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ShowsCountDown
{
    class WebScrape
    {
        String scrapedOutput;
        HttpWebResponse myHttpWebResponse;

        private StreamReader setupStream(String webAddress)
        {
            // Creates an HttpWebRequest with the specified URL. 
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(webAddress);
            // Sends the HttpWebRequest and waits for the response.			
            myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            // Gets the stream associated with the response.
            Stream receiveStream = myHttpWebResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            return new StreamReader(receiveStream, encode);
        }

        public WebScrape (String webAddress)
        {
            StreamReader reader = setupStream(webAddress);
            

            Char[] read = new Char[2048];
            int count = reader.Read(read, 0, read.Length);
            while (count > 0)
            {
                // Dumps the 256 characters on a string and displays the string to the console.
                String str = new String(read, 0, count);
                scrapedOutput += str;
                count = reader.Read(read, 0, 2048);
            }
            // Releases the resources of the response.
            myHttpWebResponse.Close();
            // Releases the resources of the Stream.
            reader.Close();
        }

        public String getHtmlOutput()
        {
            return scrapedOutput;
        }

    }


}
