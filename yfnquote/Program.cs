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

            StockQuoter quoter = new StockQuoter();
            yQuote quote = quoter.StockQuote("MSFT");
            WriteQuote(quote);
            System.Console.WriteLine();

            List<string> symbols = new List<string>();
            symbols.Add("IBM");
            symbols.Add("GOOG");
            symbols.Add("AAPL");
            symbols.Add("FNORD");

            List<yQuote> quotes = quoter.StockQuote(symbols);

            foreach (yQuote q in quotes)
            {
                WriteQuote(q);
                Console.WriteLine();
            }

            System.Console.WriteLine();
            System.Console.WriteLine("[Hit Enter to close...]");
            System.Console.ReadLine();
        }

        static void WriteQuote(yQuote quote)
        {
            Console.WriteLine("symbol={0}", quote.symbol);
            Console.WriteLine("name={0}", quote.Name);
            Console.WriteLine("bid={0}", quote.BidRealtime);
            Console.WriteLine("ask={0}", quote.AskRealtime);
            Console.WriteLine("last={0}", quote.LastTradePriceOnly);
            Console.WriteLine("time={0}", quote.LastTradeTime);
            Console.WriteLine("volume={0}", quote.Volume);
        }
    }
}
