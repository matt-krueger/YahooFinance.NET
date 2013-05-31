using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YahooFinance.NET
{
    public class StockQuoter
    {
        private string yahoo_url = "http://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.quotes%20where%20symbol%20in%20(%22||TICKER||%22)%0A%09%09&format=json&diagnostics=true&env=http%3A%2F%2Fdatatables.org%2Falltables.env";

        public yQuote StockQuote(string ticker)
        {
            return StockQuote(ticker, yahoo_url);
        }

        public List<yQuote> StockQuote(List<string> tickers)
        {
            return StockQuote(tickers, yahoo_url);
        }

        public yQuote StockQuote(string ticker, string url)
        {
            yQuote qte = new yQuote();
            JToken result = yahoo_query(url, ticker);
            qte = JsonConvert.DeserializeObject<yQuote>(result.ToString());
            return qte;
        }

        public List<yQuote> StockQuote(List<string> tickers, string url)
        {
            yQuote qte = new yQuote();
            List<yQuote> quotes = new List<yQuote>();
            string ticker_request="";
            foreach( string symbol in tickers)
            {
                ticker_request += symbol;
                ticker_request += ",";
            }
            ticker_request = ticker_request.TrimEnd(';');
            JToken result = yahoo_query(url, ticker_request);
            quotes = JsonConvert.DeserializeObject<List<yQuote>>(result.ToString());
            return quotes;
        }

        private JToken yahoo_query(string url, string ticker_request)
        {
            string requesturl = url.Replace("||TICKER||", ticker_request);

            // MAKE WEB REQUEST TO THE URL
            WebRequest request = WebRequest.Create(requesturl);
            WebResponse response = request.GetResponse();

            Stream receive = response.GetResponseStream();
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamReader read = new StreamReader(receive, encoding);

            string content = read.ReadToEnd();

            // DESERIALIZE THE JSON RESPONSE TO AN OBJECT
            JObject yahooresult = JObject.Parse(content);
            JToken result = yahooresult["query"]["results"]["quote"];

            return result;
        }
    }
}
