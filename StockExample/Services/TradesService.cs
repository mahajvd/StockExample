using StockExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockExample.Services
{
    public class TradesService
    {
        private List<Trade> _trades;
        public TradesService()
        {
            _trades = new List<Trade>();
        }

        public TradesService(List<Trade> trades)
        {
            _trades = trades ?? throw new ArgumentNullException("trades");
        }

        public List<Trade> Trades
        {
            get
            {
                return _trades;
            }
            set
            {
                _trades = value;
            }
        }

        public void RecordTrade(Stock stock, int quantity, double price)
        {
            if (quantity == 0) throw new ArgumentNullException("quantity");
            if (price == 0) throw new ArgumentNullException("price");

            Trade trade = new Trade
            {
                Stock = stock ?? throw new ArgumentNullException("stock"),
                TradeTimeStamp = DateTime.Now,
                Quantity = quantity,
                Price = price,
                BuySellDirection = quantity >= 0 ? BuySellDirection.Buy : BuySellDirection.Sell
            };
            _trades.Add(trade);
        }

        public double CalculateVolumeWeightedStockPrice(string symbolCode)
        {
            List<Trade> trades = GetAllTradesWithinInterval(symbolCode, 15);

            var totalValue = trades.Sum(trade => trade.Price * trade.Quantity);
            if (trades.Sum(trade => trade.Quantity) == 0)
            {                
                return 0;
            }

            return totalValue / trades.Sum(trade => trade.Quantity);
        }

        public List<Trade> GetAllTradesWithinInterval(string symbolCode, int minutes = 15)
        {            
            return _trades.Where(trade => trade.TradeTimeStamp > DateTime.Now.AddMinutes(minutes * -1))
                .Where(trade => trade.Stock.Symbol.Equals(symbolCode))
                .ToList();
        }
    }
}
