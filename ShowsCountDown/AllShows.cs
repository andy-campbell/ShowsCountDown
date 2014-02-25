using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace ShowsCountDown
{
    /**
     *  Contains the full list of shows from which can be queried from.
     */
    class AllShows
    {
        List<String> showsList;
        public AllShows()
        {
            showsList = new List<String>();
            buildShowList();
        }

        private String getRawShowList()
        {
            String rawShowList = "";
            // Creates an HttpWebRequest with the specified URL. 
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://tvcountdown.com/js/shows.js");
            // Sends the HttpWebRequest and waits for the response.			
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            // Gets the stream associated with the response.
            Stream receiveStream = myHttpWebResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, encode);
            Char[] read = new Char[256];
            int count = readStream.Read(read, 0, 256);
            while (count > 0)
            {
                // Dumps the 256 characters on a string and displays the string to the console.
                String str = new String(read, 0, count);
                rawShowList += str;
                count = readStream.Read(read, 0, 256);
            }
            // Releases the resources of the response.
            myHttpWebResponse.Close();
            // Releases the resources of the Stream.
            readStream.Close();
            return rawShowList;
        }
        /*
         * This gets all of the shows from www.tvcountdown.com and adds them to a list
         */
        private void buildShowList()
        {
            string rawShowList = getRawShowList();
            var reg = new Regex ("\"[^\"]*\"");
            var matches = reg.Matches(rawShowList);
            int count = 0;
            foreach (var s in matches)
            {
                if (count == 0)
                    showsList.Add(s.ToString());
                
                count++;
                if (count == 3)
                    count = 0;
                
            }
        }

        public List<String> getShowList()
        {
            return showsList;
        }
    }
}
