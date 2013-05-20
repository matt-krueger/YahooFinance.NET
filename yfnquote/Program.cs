using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YahooFinance.NET;

namespace yfntest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("yahoo finance stock quote test");
            String url = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22||TICKER||%22)%0A%09%09&format=json&diagnostics=true&env=http%3A%2F%2Fdatatables.org%2Falltables.env";

            StockQuoter quoter = new StockQuoter();
            yQuote quote = quoter.StockQuote("MSFT", url);

            Console.WriteLine("symbol={0}", quote.symbol);
            Console.WriteLine("bid={0}", quote.BidRealtime);
            Console.WriteLine("ask={0}", quote.AskRealtime);
            Console.WriteLine("last={0}", quote.LastTradePriceOnly);
            Console.WriteLine("time={0}", quote.LastTradeTime);
            Console.WriteLine("volume={0}", quote.Volume);

            System.Console.WriteLine();
            System.Console.WriteLine("[Hit Enter to close...]");
            System.Console.ReadLine();
        }
    }
}
