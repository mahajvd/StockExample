using StockExample.Model;
using System;
using System.Collections.Generic;

namespace StockExample.Services
{
    public class StocksService
    {
        private List<Stock> _stocks;
        public StocksService(List<Stock> stocks)
        {
            _stocks = stocks;
        }
        public StocksService()
        {
            _stocks = new List<Stock>();
        }

        public double? GetDividendYield(Stock stock, double marketPrice)
        {
            if (marketPrice == 0)
            {
                throw new ArgumentException("marketPrice should be greater than zero.");
            }
            if (stock == null)
            {
                throw new ArgumentNullException("stock");
            }

            switch (stock.StockType)
            {
                case StockType.Preferred:
                    return (stock.FixedDividend * stock.ParValue) / marketPrice;
                case StockType.Common:
                    return stock.LastDividend / marketPrice;
                default:
                    throw new Exception("Undefined stock type");
            }
        }

        public double? GetPERatio(Stock stock, double marketPrice)
        {
            if (stock == null)
            {
                throw new ArgumentNullException("stock");
            }
            if (stock.LastDividend == 0)
            {
                throw new ArgumentException("LastDividend should be greater than zero.");
            }

            return marketPrice / stock.LastDividend;
        }


        public double CalculateGBCEAllShareIndex()
        {            
            if (_stocks == null ||_stocks.Count == 0)
            {         
                return 0.0;
            }
            double total = 1.0;
            foreach(var stock in _stocks)
            {
                total = total * stock.MarketPrice;
            }
                        
            return Math.Pow(total, 1.0 / _stocks.Count);
        }
    }
}
