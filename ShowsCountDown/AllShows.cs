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
            WebScrape scraper = new WebScrape("http://tvcountdown.com/js/shows.js");
            return scraper.getHtmlOutput();
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
                    showsList.Add(s.ToString().Replace("\"", ""));
                
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
