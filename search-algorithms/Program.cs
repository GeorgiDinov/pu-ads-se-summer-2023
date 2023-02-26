using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string startingUrl = "http://fmi-plovdiv.org";
            new BFSBasedSimpleWebCrawler().crawlTheWebFrom(startingUrl);
        }
    }
}
