using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExample.Model
{
    public class Trade
    {          

        public Trade(Stock stock, int quantity, double price)
        {
            this.Stock = stock;
            this.Quantity = quantity;
            this.Price = price;
            this.TradeTimeStamp = DateTime.Now;
        }
        public Trade()
        {}

        public Stock Stock { get; set; }        
        public DateTime TradeTimeStamp { get; set; }
        public int Quantity { get; set; }
        public BuySellDirection BuySellDirection { get; set; }
        public double Price { get; set; }
    }
}
